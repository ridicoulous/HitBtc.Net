using HitBtc.Net.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace HitBtc.Net.Extensions
{
    public static class Extensions
    {
        public static string Normalize(this decimal? value)
        {
            if (!value.HasValue)
            {
                return null;
            }
            return (value.Value / 1.000000000000000000000000000000000m).ToString(CultureInfo.InvariantCulture);
        }
        public static Dictionary<string, object> AsDictionary(this object source,
          BindingFlags bindingAttr = BindingFlags.FlattenHierarchy |
          BindingFlags.Instance |
          BindingFlags.NonPublic |
          BindingFlags.Public |
          BindingFlags.Static)
        {
            try
            {
                var result = new Dictionary<string, object>();
                var props = source.GetType().GetProperties(bindingAttr);
                foreach (var p in props)
                {
                    if (p.IsDefined(typeof(JsonIgnoreAttribute)) ||
                        p.IsDefined(typeof(IgnoreAsParameterAttribute)))
                        continue;
                    string key = p.Name;
                    if (p.IsDefined(typeof(JsonPropertyAttribute)))
                    {
                        key = p.GetCustomAttribute<JsonPropertyAttribute>().PropertyName ?? p.Name;
                    }                  
                    object value = p.GetValue(source, null);

                    if (value == null)
                    {
                        continue;
                    }

                    if (value is bool)
                    {
                        value = value.ToString().ToLowerInvariant();
                    }
                    if (value is decimal || value is decimal?)
                    {
                        value = (value as decimal?).Normalize();                       
                            
                    }                  
                    if (p.IsDefined(typeof(JsonConverterAttribute)))
                    {
                        var att = p.GetCustomAttribute<JsonConverterAttribute>();
                        var t = Activator.CreateInstance(att.ConverterType);
                        value = JsonConvert.SerializeObject(value, t as JsonConverter);                   
                    }
                    if (!result.ContainsKey(key) && !String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(value.ToString()))
                    {
                        result.Add(key, value);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string AsStringParameterOrNull<T>(this List<T> source) => AsStringParameterOrNull(source.ToArray());

        public static string AsStringParameterOrNull<T>(this T[] source)
        {
            return (source.Length == 0) ? null : string.Join(",", source);
        }

        /// <summary>
        /// Retrieves an enum item from a specified string by matching the string to the RepresentAsAttribute
        /// elements assigned to each enum item
        /// </summary>
        /// <typeparam name="TEnum">The enum type that should be returned</typeparam>
        /// <param name="description">The description that should be searched</param>
        /// <param name="ignoreCase">Whether string comparison of descriptions should be case-sensitive or not</param>
        /// <returns>The matched enum item</returns>
        /// <exception cref="ArgumentException">Thrown if no enum item could be found with the corresponding description</exception>
        public static TEnum AsEnumEntry<TEnum>(this string description, bool ignoreCase = true) 
            // Add a condition to the generic type
            where TEnum : Enum
        {
            // Loop through all the items in the specified enum
            foreach (var item in typeof(TEnum).GetFields())
            {
                // Check to see if the enum item has a Description attribute
                if (Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute)) is
                    DescriptionAttribute attribute)
                {
                    // If the enum item has a description attribute, then check if
                    // the description matches the given description parameter
                    if (string.Equals(attribute.Description, description,
                        ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                        return (TEnum) item.GetValue(null);
                }
            }

            // If no enum item was found with the specified description, throw an
            // exception
            throw new ArgumentException($"Enum item with description \"{description}\" could not be found",
                nameof(description));
        }

         public static string AsStringByDescriptionAttribute<TEnum>(this TEnum enumEntry)
         where TEnum : Enum
         {
            var enumMemb = enumEntry.GetType().GetMember(enumEntry.ToString());
            foreach (var item in enumMemb)
            {
                if (item.GetCustomAttributes(typeof(DescriptionAttribute)) is
                     DescriptionAttribute attribute)
                {
                    return attribute.Description;
                }
            }

            // If enum item has not the RepresentAs attribute, throw an
            // exception
            throw new ArgumentException("Enum item  has not the RepresentAs attribute");
        }
    }
}
