using System;
using System.Collections.Generic;
using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumTests;

[TestClass]
public class ParseShortNameShould
{
    [TestMethod]
    public void ReturnsValueGivenCasingMismatchAndIgnoringCase()
    {
        var shortName = DemoStatus.OnHold.ToShortName().ToUpperInvariant();

        Enum<DemoStatus>.ParseShortName(shortName, true);
    }

    [TestMethod]
    public void ReturnsValueGivenExactMatch()
    {
        var shortName = DemoStatus.OnHold.ToShortName();
        Enum<DemoStatus>.ParseShortName(shortName);
    }

    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void ThrowsExceptionGivenCasingMismatch()
    {
        var shortName = DemoStatus.OnHold.ToShortName().ToUpperInvariant();

        Enum<DemoStatus>.ParseShortName(shortName);
    }

    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void ThrowsExceptionGivenNoMatch()
    {
        Enum<DemoStatus>.ParseShortName(Guid.NewGuid().ToString());
    }
}