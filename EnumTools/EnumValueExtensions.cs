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
        return attribute?.GetDescription();
    }

    public static string ToName(this Enum enumerationValue)
    {
        var attribute = GetDisplayAttribute(enumerationValue);
        return ValueOrToString(attribute?.GetName(), enumerationValue);
    }

    public static string ToShortName(this Enum enumerationValue)
    {
        var attribute = GetDisplayAttribute(enumerationValue);
        return ValueOrToString(attribute?.GetShortName() ?? attribute?.GetName(), enumerationValue);
    }

    public static string? GroupName(this Enum enumerationValue)
    {
        var attribute = GetDisplayAttribute(enumerationValue);
        return attribute?.GetGroupName();
    }

    public static string? Prompt(this Enum enumerationValue)
    {
        var attribute = GetDisplayAttribute(enumerationValue);
        return attribute?.GetPrompt();
    }

    public static bool? GetAutoGenerateField(this Enum enumerationValue)
    {
        var attribute = GetDisplayAttribute(enumerationValue);
        return attribute?.GetAutoGenerateField();
    }

    public static bool? GetAutoGenerateFilter(this Enum enumerationValue)
    {
        var attribute = GetDisplayAttribute(enumerationValue);
        return attribute?.GetAutoGenerateFilter();
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