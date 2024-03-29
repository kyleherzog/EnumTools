﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EnumTools;

public static class Enum<T> where T: struct, IComparable, IFormattable
{
    public static T MaximumValue
    {
        get
        {
            AssertIsEnum();

            var result = Enum.GetValues(typeof(T)).Cast<T>().Max();
            return result;
        }
    }

    public static T MinimumValue
    {
        get
        {
            AssertIsEnum();

            var result = Enum.GetValues(typeof(T)).Cast<T>().Min();
            return result;
        }
    }

    /// <summary>
    /// Finds the enum value that has a matching DisplayAttribute ShortName property. A parameter specifies whether the operation is case-insensitive.
    /// </summary>
    /// <param name="value">The string name to match against the DisplayAttribute ShortName property.</param>
    /// <param name="ignoreCase">true to ignore case; false to regard case.</param>
    /// <returns></returns>
    public static T ParseShortName(string value, bool ignoreCase = false)
    {
        if (TryParseShortName(value, ignoreCase, out var result))
        {
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"An enum value of '{value}' could not be found matching the DisplayAttribute ShortName property in the values for '{typeof(T)}'.");
        }
    }

    /// <summary>
    /// Converts the case-sensitive string representation of the DisplayAttribute ShortName property to the actual enumerated object.  The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The string representation to match against the DisplayAttribute ShortName property to convert.</param>
    /// <param name="result">When this method returns, result contains an object of type T whose DisplayAttribute ShortName property is represented by value if the parse operation succeeds. If the parse operation fails, result contains the first value of the underlying type of T.</param>
    /// <returns>true if the value parameter was converted successfully; otherwise, false.</returns>
    public static bool TryParseShortName(string value, out T result)
    {
        return TryParseShortName(value, false, out result);
    }

    /// <summary>
    /// Converts the string representation of the DisplayAttribute ShortName property to the actual enumerated object.  A parameter specifies whether the operation is case-sensitive.  The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The string representation to match against the DisplayAttribute ShortName property to convert.</param>
    /// <param name="ignoreCase">true to ignore case; false to consider case.</param>
    /// <param name="result">When this method returns, result contains an object of type T whose DisplayAttribute ShortName property is represented by value if the parse operation succeeds. If the parse operation fails, result contains the first value of the underlying type of T. Note that if match case-insensitive, case-sensitive match will still be the prefered result in the case of multile matches.</param>
    /// <returns>true if the value parameter was converted successfully; otherwise, false.</returns>
    public static bool TryParseShortName(string value, bool ignoreCase, out T result)
    {
        var infos = AllInfo();
        var infoMatch = infos.FirstOrDefault(i => i.ShortName != null && i.ShortName.Equals(value));

        if (infoMatch == null && ignoreCase)
        {
            infoMatch = infos.FirstOrDefault(i => i.ShortName != null &&  i.ShortName.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        if (infoMatch == null)
        {
            result = default;
            return false;
        }
        else
        {
            result = infoMatch.Value;
            return true;
        }
    }

    public static IEnumerable<EnumValueInfo<T>> AllInfo()
    {
        AssertIsEnum();
        var names = Enum.GetNames(typeof(T));
        var results = new List<EnumValueInfo<T>>();
        foreach (var name in names)
        {
            results.Add(new EnumValueInfo<T>(name));
        }
        return results;
    }

    public static IEnumerable<EnumValueInfo<T>> InfoByGroup(string? groupName)
    {
        return AllInfo().Where(i => i.GroupName == groupName);
    }

    public static IEnumerable<string> GroupNames()
    {
        return AllInfo().Where(i => !string.IsNullOrEmpty(i.GroupName)).Select(i => i.GroupName).Distinct();
    }

    private static void AssertIsEnum()
    {
        var enumType = typeof(T).GetTypeInfo();
        if (!enumType.IsEnum)
        {
            throw new ArgumentException($"{nameof(T)} must be an enumerated type.");
        }
    }
}
