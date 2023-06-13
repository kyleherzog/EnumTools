using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumTests;

[TestClass]
public class MinimumValueShould
{
    [TestMethod]
    public void ReturnsMinimumValue()
    {
        Assert.AreEqual(DemoStatus.None, Enum<DemoStatus>.MinimumValue);
    }
}