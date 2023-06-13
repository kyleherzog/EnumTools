using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumValueExtensionsTests;

[TestClass]
public class DescriptionShould
{
    [TestMethod]
    public void ReturnDescriptionGivenDisplayDescriptionSpecified()
    {
        var status = DemoStatus.OnDeck;
        var expected = "Not started yet.";
        Assert.AreEqual(expected, status.Description());
    }

    [TestMethod]
    public void ReturnNullGivenNoDisplayDescription()
    {
        var status = DemoStatus.Active;
        Assert.IsNull(status.Description());
    }

    [TestMethod]
    public void ReturnNullGivenUndefinedValue()
    {
        var value = 9999;
        var status = (DemoStatus)value;
        Assert.IsNull(status.Description());
    }
}