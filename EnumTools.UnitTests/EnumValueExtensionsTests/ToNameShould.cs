using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumValueExtensionsTests;

[TestClass]
public class ToNameShould
{
    [TestMethod]
    public void ReturnAttributePropertyValueGivenDisplayNameSpecified()
    {
        var status = DemoStatus.None;
        var expected = "--Select a Status--";
        Assert.AreEqual(expected, status.ToName());
    }

    [TestMethod]
    public void ReturnEnumToStringGivenAttributeWithoutNameProperty()
    {
        var status = DemoStatus.Active;
        var expected = status.ToString();
        Assert.AreEqual(expected, status.ToName());
    }

    [TestMethod]
    public void ReturnValueToStringGivenNoAttribute()
    {
        var status = DemoStatus.Other;
        var expected = status.ToString();
        Assert.AreEqual(expected, status.ToName());
    }
}