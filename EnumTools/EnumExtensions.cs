using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnumTools
{
    public static class EnumExtensions
    {
        public static string ToDescription(this Enum enumerationValue)
        {
            var attribute = GetDisplayAttribute(enumerationValue);
            return ValueOrToString(attribute?.Description, enumerationValue);
        }

        public static string ToName(this Enum enumerationValue)
        {
            var attribute = GetDisplayAttribute(enumerationValue);
            return ValueOrToString(attribute?.Name, enumerationValue);
        }

        public static string ToShortName(this Enum enumerationValue)
        {
            var attribute = GetDisplayAttribute(enumerationValue);
            return ValueOrToString(attribute?.ShortName ?? attribute?.Name, enumerationValue);
        }

        public static string GroupName(this Enum enumerationValue)
        {
            var attribute = GetDisplayAttribute(enumerationValue);
            return attribute?.GroupName;
        }

        public static string Prompt(this Enum enumerationValue)
        {
            var attribute = GetDisplayAttribute(enumerationValue);
            return attribute?.Prompt;
        }
               public static int? GetOrder(this Enum enumerationValue)
        {
            var attribute = GetDisplayAttribute(enumerationValue);
            return attribute.GetOrder();
        }



        private static string ValueOrToString(string value, Enum enumerationValue)
        {
            return string.IsNullOrEmpty(value) ? enumerationValue.ToString() : value;
        }

        private static DisplayAttribute GetDisplayAttribute(Enum enumerationValue)
        {
            if (enumerationValue == null)
                throw new ArgumentNullException(nameof(enumerationValue));

            var type = enumerationValue.GetType();

            var info = type.GetRuntimeField(enumerationValue.ToString());
        

            if (info != null)
            {
                return info.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
            }
            return null;
        }

       
    }
}
