using System.Linq;
using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumTests;

[TestClass]
public class AllInfoShould
{
    [TestMethod]
    public void ReturnAllItems()
    {
        var items = Enum<DemoStatus>.AllInfo();
        var expectedCount = 7;
        Assert.AreEqual(expectedCount, items.Count());
    }
}