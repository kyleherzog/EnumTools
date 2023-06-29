using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumValueExtensionsTests;

[TestClass]
public class GetAutoGenerateFieldShould
{
    [TestMethod]
    public void ReturnNullGivenNoAttribute()
    {
        var status = DemoStatus.Other;
        Assert.IsFalse(status.GetAutoGenerateField().HasValue);
    }

    [TestMethod]
    public void ReturnNullGivenNotSpecified()
    {
        var status = DemoStatus.OnDeck;
        Assert.IsFalse(status.GetAutoGenerateField().HasValue);
    }

    [TestMethod]
    public void ReturnValueGivenSpecified()
    {
        var status = DemoStatus.Active;
        Assert.IsTrue(status.GetAutoGenerateField());
    }
}