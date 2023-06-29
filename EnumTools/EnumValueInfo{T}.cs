using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EnumTools;

public class EnumValueInfo<T> where T : struct, IFormattable, IComparable
{
    private DisplayAttribute? display;

    public EnumValueInfo(string valueName)
    {
        DefaultName = valueName;
        Value = (T)Enum.Parse(typeof(T), valueName);
    }

    public EnumValueInfo(T value)
    {
        DefaultName = value.ToString();
        Value = value;
    }

    public bool? AutoGenerateField => Display.GetAutoGenerateField();

    public bool? AutoGenerateFilter => Display.GetAutoGenerateFilter();

    public string DefaultName
    {
        get;
    }

    public string Description
    {
        get
        {
            return Display.GetDescription();
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
            if (display == null)
            {
                LoadDisplay();
            }

            return display!;
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
            return Display.GetPrompt();
        }
    }

    public string GroupName
    {
        get
        {
            return Display.GetGroupName();
        }
    }

    public string Name
    {
        get
        {
            return Display.GetName();
        }
    }

    public string NameOrDefault
    {
        get
        {
            return Display.GetName() ?? DefaultName;
        }
    }

    public string ShortName
    {
        get
        {
            return Display.GetShortName();
        }
    }

    public string ShortNameOrDefault
    {
        get
        {
            return Display.GetShortName() ?? DefaultName;
        }
    }

    public T Value { get; }

    private void LoadDisplay()
    {
        var type = Value.GetType();

        var field = type.GetRuntimeField(DefaultName);

        if (field != null)
        {
            display = field.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
        }

        display ??= new DisplayAttribute();
    }
}
