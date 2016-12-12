using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnumTools.Tests
{
    public enum DemoStatus
    {
        [Display(Name = "--Select a Status--")]
        None = 0,

        [Display(GroupName = "Open", Order = 1)]
        Active = 1,

        [Display(Description = "Same as inactive.", GroupName = "Closed")]
        Deleted = 2,

        [Display(Name = "On Hold", Description = "Used when item is on hold.", ShortName = "Hold", GroupName = "Open", Prompt = "Watermark here")]
        OnHold = 3,

        [Display(Description = "Not started yet.", Name = "On Deck", GroupName = "Open")]
        OnDeck = 4,

        [Display(GroupName = "Closed")]
        Canceled = 5


    }
}
