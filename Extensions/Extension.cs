using CryptoExchange.Net.Converters;
using HitBtc.Net.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

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
    }
}
