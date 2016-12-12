using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EnumTools
{
    public static class Enum<T> where T: struct, IComparable, IFormattable
    {
        public static T MaximumValue 
        {
            get
            {
                AssertIsEnum();

                T result = Enum.GetValues(typeof(T)).Cast<T>().Max();
                return result;
            }
        }

        public static T MinimumValue
        {
            get
            {
                AssertIsEnum();

                T result = Enum.GetValues(typeof(T)).Cast<T>().Min();
                return result;
            }
        }

        public static IEnumerable<EnumInfo<T>> AllInfo()
        {
            AssertIsEnum();
            var names = Enum.GetNames(typeof(T));
            var results = new List<EnumInfo<T>>();
            foreach (var name in names)
            {
                results.Add(new EnumInfo<T>(name));
            }
            return results;
        }

        public static IEnumerable<EnumInfo<T>> InfoByGroup(string groupName)
        {
            return AllInfo().Where(i => i.GroupName == groupName);
        }

        public static IEnumerable<string> GroupNames()
        {
            return AllInfo().Where(i => !string.IsNullOrEmpty(i.GroupName)).Select(i => i.GroupName).Distinct();
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
