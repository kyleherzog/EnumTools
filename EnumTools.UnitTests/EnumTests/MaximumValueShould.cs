using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumTests;

[TestClass]
public class MaximumValueShould
{
    [TestMethod]
    public void ReturnsMaximumValue()
    {
        Assert.AreEqual(DemoStatus.Other, Enum<DemoStatus>.MaximumValue);
    }
}