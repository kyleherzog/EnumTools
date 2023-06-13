using System;
using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumTests;

[TestClass]
public class TryParseShortNameShould
{
    [TestMethod]
    public void ReturnFalseGivenCaseMismatch()
    {
        var shortName = DemoStatus.OnHold.ToShortName().ToUpperInvariant();

        Assert.IsFalse(Enum<DemoStatus>.TryParseShortName(shortName, out var result));
        Assert.AreEqual(default, result);
    }

    [TestMethod]
    public void ReturnFalseGivenNoMatch()
    {
        Assert.IsFalse(Enum<DemoStatus>.TryParseShortName(Guid.NewGuid().ToString(), out var result));
        Assert.AreEqual(default, result);
    }

    [TestMethod]
    public void ReturnTrueGivenCaseInsensitiveMatchAndIgnoringCase()
    {
        var expectedResult = DemoStatus.OnHold;
        var shortName = expectedResult.ToShortName().ToUpperInvariant();

        Assert.IsTrue(Enum<DemoStatus>.TryParseShortName(shortName, true, out var result));
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void ReturnTrueGivenExactMatch()
    {
        var expectedResult = DemoStatus.OnHold;
        var shortName = expectedResult.ToShortName();

        Assert.IsTrue(Enum<DemoStatus>.TryParseShortName(shortName, out var result));
        Assert.AreEqual(expectedResult, result);
    }
}