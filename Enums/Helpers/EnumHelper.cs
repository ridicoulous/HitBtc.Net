using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace HitBtc.Net.Enums.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Create a Dictionary from enum. 
        /// The string specified by DescriptionAttribute as key and enum entry as value.
        /// DescriptionAttribute for enum's members is required
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        public static Dictionary<string, T> MapToDictionaryOfStringEnumPair<T>(Type enumeration)
        where T : struct, IConvertible
        {
            if (!enumeration.IsEnum)
                throw new ArgumentException("enumeration is not an Enum.");

            var dict = new Dictionary<string, T>();
            foreach (T enumEntry in Enum.GetValues(enumeration))
            {
                var enumMemb = enumEntry.GetType().GetMember(enumEntry.ToString());
                foreach (var item in enumMemb)
                {
                    if (item.GetCustomAttributes(typeof(DescriptionAttribute)) is
                         DescriptionAttribute attribute)
                    {
                        dict.Add(attribute.Description, enumEntry);
                    }
                }
            }
            return dict;
        }

        /// <summary>
        /// Create List of KeyValuePair from enum. 
        /// The enum entry as value and the string specified by DescriptionAttribute as key of KeyValuePair. 
        /// DescriptionAttribute for enum's members is required
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        public static List<KeyValuePair<IConvertible, string>> MapToListOfEnumStringPair(Type enumeration)
        {
            if (!enumeration.IsEnum)
                throw new ArgumentException("enumeration is not an Enum.");

            var list = new List<KeyValuePair<IConvertible, string>>();
            foreach (IConvertible enumEntry in Enum.GetValues(enumeration))
            {
                var enumMemb = enumEntry.GetType().GetMember(enumEntry.ToString());
                foreach (var item in enumMemb)
                {
                    if (item.GetCustomAttributes(typeof(DescriptionAttribute)) is
                         DescriptionAttribute attribute)
                    {
                        list.Add(new KeyValuePair<IConvertible, string>(enumEntry, attribute.Description));
                    }
                }
            }
            return list;
        }
    }
}