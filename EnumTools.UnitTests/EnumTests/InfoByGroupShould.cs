using System.Linq;
using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumTests;

[TestClass]
public class InfoByGroupShould
{
    [TestMethod]
    public void ReturnEmptyGivenNoMatchingItems()
    {
        var items = Enum<DemoStatus>.InfoByGroup("DO_NOT_FIND");
        Assert.IsFalse(items.Any());
    }

    [TestMethod]
    public void ReturnItemsGivenNullGroupName()
    {
        var items = Enum<DemoStatus>.InfoByGroup(null);
        var expectedCount = 2;
        Assert.AreEqual(expectedCount, items.Count());
        Assert.IsTrue(items.Any(i => i.Value == DemoStatus.None));
        Assert.IsTrue(items.Any(i => i.Value == DemoStatus.Other));
    }

    [TestMethod]
    public void ReturnOnlyItemsWithMatchingGroupName()
    {
        var items = Enum<DemoStatus>.InfoByGroup("Closed");
        var expectedCount = 2;
        Assert.AreEqual(expectedCount, items.Count());
        Assert.IsTrue(items.Any(i => i.Value == DemoStatus.Canceled));
        Assert.IsTrue(items.Any(i => i.Value == DemoStatus.Deleted));
    }
}