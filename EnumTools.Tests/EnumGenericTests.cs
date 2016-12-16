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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseShortNameThrowsArgumentExceptionWhenNoMatchFound()
        {
            Enum<DemoStatus>.ParseShortName(Guid.NewGuid().ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseShortNameThrowsArumentExceptionWhenImplicitlyCaseSentitiveMatchingAndNoMatch()
        {
            var shortName = DemoStatus.OnHold.ToShortName().ToUpperInvariant();

            Enum<DemoStatus>.ParseShortName(shortName);
        }

        [TestMethod]
        public void ParseShortNameReturnsFirstMatchingValue()
        {
            var shortName = DemoStatus.OnHold.ToShortName();
            Enum<DemoStatus>.ParseShortName(shortName);
        }

        [TestMethod]
        public void ParseShortNameReturnsFirstCaseInsensitiveMatch()
        {
            var shortName = DemoStatus.OnHold.ToShortName().ToUpperInvariant();

            Enum<DemoStatus>.ParseShortName(shortName, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseShortNameThrowsArumentExceptionWhenExplicitlyCaseSentitiveMatchingAndNoMatch()
        {
            var shortName = DemoStatus.OnHold.ToShortName().ToUpperInvariant();

            Enum<DemoStatus>.ParseShortName(shortName, false);
        }

        [TestMethod]
        public void TryParseShortNameReturnsTrueAndSetsResultWhenMatchFound()
        {
            var expectedResult = DemoStatus.OnHold;
            var shortName = expectedResult.ToShortName();

            DemoStatus result;
            Assert.IsTrue(Enum<DemoStatus>.TryParseShortName(shortName, out result));
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TryParseShortNameReturnsTrueAndSetsResultToFirstCaseInsensitiveMatch()
        {
            var expectedResult = DemoStatus.OnHold;
            var shortName = expectedResult.ToShortName().ToUpperInvariant();

            DemoStatus result;
            Assert.IsTrue(Enum<DemoStatus>.TryParseShortName(shortName, true, out result));
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TryParseShortNameReturnsFalseWhenNoMatchFound()
        {
            DemoStatus result;
            Assert.IsFalse(Enum<DemoStatus>.TryParseShortName(Guid.NewGuid().ToString(), out result));
        }

        [TestMethod]
        public void ParseShortNameReturnsFalseWhenExplicitlyCaseSentitiveMatchingAndNoMatch()
        {
            var shortName = DemoStatus.OnHold.ToShortName().ToUpperInvariant();

            DemoStatus result;
            Assert.IsFalse(Enum<DemoStatus>.TryParseShortName(shortName, false, out result));
        }

        [TestMethod]
        public void ParseShortNameReturnsFalseWhenImplicitlyCaseSentitiveMatchingAndNoMatch()
        {
            var shortName = DemoStatus.OnHold.ToShortName().ToUpperInvariant();

            DemoStatus result;
            Assert.IsFalse(Enum<DemoStatus>.TryParseShortName(shortName, out result));
        }


    }
}
