using EnumTools.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumTools.UnitTests.EnumValueExtensionsTests;

[TestClass]
public class GroupNameShould
{
    [TestMethod]
    public void ReturnGroupNameGivenSpecified()
    {
        var status = DemoStatus.Deleted;
        var expected = "Closed";
        Assert.AreEqual(expected, status.GroupName());
    }

    [TestMethod]
    public void ReturnNullGivenNoAttribute()
    {
        var status = DemoStatus.Other;
        Assert.IsNull(status.GroupName());
    }

    [TestMethod]
    public void ReturnNullGivenNoGroupNameSpecified()
    {
        var status = DemoStatus.None;
        Assert.IsNull(status.GroupName());
    }
}