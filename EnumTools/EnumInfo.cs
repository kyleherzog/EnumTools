using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EnumTools
{
    public class EnumInfo<T> where T : struct, IFormattable, IComparable
    {
        private DisplayAttribute _display;

        public EnumInfo(string valueName)
        {
            DefaultName = valueName;
            Value = (T)Enum.Parse(typeof(T), valueName);
        }

        public EnumInfo(T value)
        {
            DefaultName = value.ToString();
            Value = value;
        }

        public string DefaultName
        {
            get;
        }

        public string Description
        {
            get
            {
                return Display.Description;
            }
        }

        public string DescriptionOrDefault
        {
            get
            {
                return Description ?? DefaultName;
            }
        }

        public DisplayAttribute Display
        {
            get
            {
                if (_display == null)
                    LoadDisplay();
                return _display;
            }
        }

        public int? Order
        {
            get
            {
                return Display.GetOrder();
            }
        }

        public string Prompt
        {
            get
            {
                return Display.Prompt;
            }
        }

        public string GroupName
        {
            get
            {
                return Display.GroupName;
            }
        }

        public string Name
        {
            get
            {
                return Display.Name;
            }
        }

        public string NameOrDefault
        {
            get
            {
                return Display.Name ?? DefaultName;
            }
        }

        public string ShortName
        {
            get
            {
                return Display.ShortName;
            }
        }

        public string ShortNameOrDefault
        {
            get
            {
                return Display.ShortName ?? DefaultName;
            }
        }

        public T Value { get; }

        private static string ValueOrToString(string value, Enum enumerationValue)
        {
            return string.IsNullOrEmpty(value) ? enumerationValue.ToString() : value;
        }

        private void LoadDisplay()
        {            
            var type = Value.GetType();

            var field = type.GetRuntimeField(DefaultName);

            if (field != null)
            {
                _display = field.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
            }  
            
            if (_display == null)
            {
                _display = new DisplayAttribute();
            }        
        }

        private static void AssertIsEnum()
        {
            TypeInfo enumType = typeof(T).GetTypeInfo();
            if (!enumType.IsEnum)
            {
                throw new ArgumentException($"{nameof(T)} must be an enumerated type.");
            }
        }
    }
}
