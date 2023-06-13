using System;
using System.Linq;
using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumTests;

[TestClass]
public class GroupNamesShould
{
    [TestMethod]
    public void ReturnsDistinctGroupNames()
    {
        var names = Enum<DemoStatus>.GroupNames();
        var expectedCount = 2;
        Assert.AreEqual(expectedCount, names.Count());
        Assert.IsTrue(names.Contains("Open"));
        Assert.IsTrue(names.Contains("Closed"));
    }
}