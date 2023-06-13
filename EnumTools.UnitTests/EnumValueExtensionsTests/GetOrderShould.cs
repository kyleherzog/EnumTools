using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumValueExtensionsTests;

[TestClass]
public class GetOrderShould
{
    [TestMethod]
    public void ReturnNullGivenNoAttribute()
    {
        var status = DemoStatus.Other;
        Assert.IsFalse(status.GetOrder().HasValue);
    }

    [TestMethod]
    public void ReturnNullGivenNotSpecified()
    {
        var status = DemoStatus.None;
        Assert.IsFalse(status.GetOrder().HasValue);
    }

    [TestMethod]
    public void ReturnOrderGivenSpecified()
    {
        var status = DemoStatus.Active;
        var expected = 1;
        Assert.AreEqual(expected, status.GetOrder());
    }
}