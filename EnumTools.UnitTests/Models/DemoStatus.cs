using System.ComponentModel.DataAnnotations;

namespace EnumTools.UnitTests.Models;

public enum DemoStatus
{
    [Display(Name = "--Select a Status--", AutoGenerateField = false)]
    None = 0,

    [Display(GroupName = "Open", Order = 1, AutoGenerateField = true, AutoGenerateFilter = true)]
    Active = 1,

    [Display(Description = "Same as inactive.", GroupName = "Closed")]
    Deleted = 2,

    [Display(Name = "On Hold", Description = "Used when item is on hold.", ShortName = "Hold", GroupName = "Open", Prompt = "Watermark here")]
    OnHold = 3,

    [Display(Description = "Not started yet.", Name = "On Deck", GroupName = "Open")]
    OnDeck = 4,

    [Display(GroupName = "Closed", AutoGenerateFilter = false)]
    Canceled = 5,

    // Use this one for testing for not attribute
    Other = 6,
}