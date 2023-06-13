using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumValueExtensionsTests;

[TestClass]
public class PromptShould
{
    [TestMethod]
    public void ReturnNullGivenNoAttribute()
    {
        var status = DemoStatus.Other;
        Assert.IsNull(status.Prompt());
    }

    [TestMethod]
    public void ReturnNullGivenNotSpecified()
    {
        var status = DemoStatus.None;
        Assert.IsNull(status.Prompt());
    }

    [TestMethod]
    public void ReturnPromptGivenSpecified()
    {
        var status = DemoStatus.OnHold;
        var expected = "Watermark here";
        Assert.AreEqual(expected, status.Prompt());
    }
}