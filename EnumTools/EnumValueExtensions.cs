using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EnumTools;

public static class EnumValueExtensions
{
    public static string? Description(this Enum enumerationValue)
    {
        var attribute = GetDisplayAttribute(enumerationValue);
        return attribute?.Description;
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

    public static string? GroupName(this Enum enumerationValue)
    {
        var attribute = GetDisplayAttribute(enumerationValue);
        return attribute?.GroupName;
    }

    public static string? Prompt(this Enum enumerationValue)
    {
        var attribute = GetDisplayAttribute(enumerationValue);
        return attribute?.Prompt;
    }

    public static int? GetOrder(this Enum enumerationValue)
    {
        var attribute = GetDisplayAttribute(enumerationValue);
        return attribute?.GetOrder();
    }

    private static string ValueOrToString(string? value, Enum enumerationValue)
    {
        if (!string.IsNullOrEmpty(value))
        {
            return value!;
        }

        return enumerationValue.ToString();
    }

    private static DisplayAttribute? GetDisplayAttribute(Enum enumerationValue)
    {
        if (enumerationValue == null)
        {
            throw new ArgumentNullException(nameof(enumerationValue));
        }

        var type = enumerationValue.GetType();

        var info = type.GetRuntimeField(enumerationValue.ToString());

        if (info != null)
        {
            return info.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
        }

        return null;
    }
}