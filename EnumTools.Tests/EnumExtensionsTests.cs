using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnumTools;

namespace EnumTools.Tests
{
    [TestClass]
    public class EnumExtensionsTests
    {
        [TestMethod]
        public void ToDescriptionOnUndefinedValueReturnsNumericStringValue()
        {
            var value = 9999;
            var status = (DemoStatus)value;
            Assert.AreEqual(value.ToString(), status.ToDescription());
        }

        [TestMethod]
        public void ToDescriptionOnValueWithoutDescriptionReturnsValueToString()
        {
            var status = DemoStatus.Active;
            Assert.AreEqual(status.ToString(), status.ToDescription());
        }

        [TestMethod]
        public void ToDescriptionOnValueWithDescriptionReturnsDescription()
        {
            var status = DemoStatus.OnDeck;
            var expected = "Not started yet.";
            Assert.AreEqual(expected, status.ToDescription());
        }

        [TestMethod]
        public void ToNameOnValueWithNameReturnsName()
        {
            var status = DemoStatus.None;
            var expected = "--Select a Status--";
            Assert.AreEqual(expected, status.ToName());
        }

        [TestMethod]
        public void ToNameOnValueWithoutNameReturnsValueToString()
        {
            var status = DemoStatus.Active;
            var expected = status.ToString();
            Assert.AreEqual(expected, status.ToName());
        }

        [TestMethod]
        public void ToNameOnValueWithDisplayAttributeButNoNameParameterReturnsValueToString()
        {
            var status = DemoStatus.Deleted;
            var expected = status.ToString();
            Assert.AreEqual(expected, status.ToName());
        }

        [TestMethod]
        public void ToNameOnValueWithMultipleDisplayAttributesParametersReturnsName()
        {
            var status = DemoStatus.OnDeck;
            var expected = "On Deck";
            Assert.AreEqual(expected, status.ToName());
        }

        [TestMethod]
        public void ToShortNameOnValueWithoutShortNameReturnsValueToString()
        {
            var status = DemoStatus.Active;
            Assert.AreEqual(status.ToString(), status.ToShortName());
        }

        [TestMethod]
        public void ToShortNameOnValueWithShortNameReturnsShortName()
        {
            var status = DemoStatus.OnHold;
            var expected = "Hold";
            Assert.AreEqual(expected, status.ToShortName());
        }

        [TestMethod]
        public void ToShortNameOnValueWithoutShortNameButWithNameReturnsName()
        {
            var status = DemoStatus.OnDeck;
            var expected = "On Deck";
            Assert.AreEqual(expected, status.ToShortName());
        }

        [TestMethod]
        public void GroupNameOnValueWithoutGroupNameReturnsNull()
        {
            var status = DemoStatus.None;
            Assert.IsNull(status.GroupName());
        }

        [TestMethod]
        public void GroupNameOnValueWithGroupNameReturnsGroupName()
        {
            var status = DemoStatus.Deleted;
            var expected = "Closed";
            Assert.AreEqual(expected, status.GroupName());
        }

        [TestMethod]
        public void PromptOnValueWithoutPromptReturnsNull()
        {
            var status = DemoStatus.None;
            Assert.IsNull(status.Prompt());
        }

        [TestMethod]
        public void PromptOnValueWithPrmptReturnsPrompt()
        {
            var status = DemoStatus.OnHold;
            var expected = "Watermark here";
            Assert.AreEqual(expected, status.Prompt());
        }

        [TestMethod]
        public void GetOrderOnValueWithoutOrderReturnsNull()
        {
            var status = DemoStatus.None;
            Assert.IsFalse(status.GetOrder().HasValue);
        }

        [TestMethod]
        public void GetOrderOnValueWithGroupNameReturnsOrder()
        {
            var status = DemoStatus.Active;
            var expected = 1;
            Assert.AreEqual(expected, status.GetOrder());
        }


    }
}
