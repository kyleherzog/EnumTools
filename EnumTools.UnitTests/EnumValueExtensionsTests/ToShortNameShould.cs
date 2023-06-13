using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumValueExtensionsTests;

[TestClass]
public class ToShortNameShould
{
    [TestMethod]
    public void ReturnNameGivenNoShortNameButName()
    {
        var status = DemoStatus.OnDeck;
        var expected = "On Deck";
        Assert.AreEqual(expected, status.ToShortName());
    }

    [TestMethod]
    public void ReturnShortNameGivenDisplayShortNameSpecified()
    {
        var status = DemoStatus.OnHold;
        var expected = "Hold";
        Assert.AreEqual(expected, status.ToShortName());
    }

    [TestMethod]
    public void ReturnValueToStringGivenNoShortNameProperty()
    {
        var status = DemoStatus.Active;
        Assert.AreEqual(status.ToString(), status.ToShortName());
    }

    [TestMethod]
    public void ReturnValueToStringGiveNoAttribute()
    {
        var status = DemoStatus.Other;
        Assert.AreEqual(status.ToString(), status.ToShortName());
    }
}