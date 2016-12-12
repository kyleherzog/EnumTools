using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnumTools;
using System.Linq;

namespace EnumTools.Tests
{
    /// <summary>
    /// Summary description for EnumGenericTests
    /// </summary>
    [TestClass]
    public class EnumGenericTests
    {
        [TestMethod]
        public void MaximumValueReturnsCorrectly()
        {
            Assert.AreEqual(DemoStatus.Canceled, Enum<DemoStatus>.MaximumValue);
        }

        [TestMethod]
        public void MinValueReturnsCorrectly()
        {
            Assert.AreEqual(DemoStatus.None, Enum<DemoStatus>.MinimumValue);
        }

        [TestMethod]
        public void AllInfoReturnsAllItems()
        {
            var items = Enum<DemoStatus>.AllInfo();
            var expectedCount = 6;
            Assert.AreEqual(expectedCount, items.Count());                        
        }

        [TestMethod]
        public void InfoByGroupReturnsOnlyItemsWithMatchingGroupName()
        {
            var items = Enum<DemoStatus>.InfoByGroup("Closed");
            var expectedCount = 2;
            Assert.AreEqual(expectedCount, items.Count());
            Assert.IsTrue(items.Any(i => i.Value == DemoStatus.Canceled));
            Assert.IsTrue(items.Any(i => i.Value == DemoStatus.Deleted));
        }

        [TestMethod]
        public void GroupNamesReturnsDistinctGroupNames()
        {
            var names = Enum<DemoStatus>.GroupNames();
            var expectedCount = 2;
            Assert.AreEqual(expectedCount, names.Count());
            Assert.IsTrue(names.Contains("Open"));
            Assert.IsTrue(names.Contains("Closed"));
        }
    }
}
