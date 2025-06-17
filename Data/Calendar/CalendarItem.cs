using Microsoft.EntityFrameworkCore;
using Qimmah.Data.Localization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Qimmah.Data.Base;

namespace Qimmah.Data.Calendar
{
    // Main Calendar Item entity (Timeline Item)
    [Table("CalendarItems",Schema = "Calendar")]
    public class CalendarItem :  EntityBase<long> 
    {
   
        public DateTime EventDate { get; set; } 
        public int DayNumber { get; set; } 
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
   


        public ICollection<CalendarItemLocalization> CalendarItemLocalizations { get; set; }
        public ICollection<Timeline> Timelines { get; set; }
    }
    // Calendar Item localization
    [Table("CalendarItems_Localization", Schema = "Calendar")]
    public class CalendarItemLocalization : BaseLocalization
    {
        public long CalendarItemID { get; set; }

        [ForeignKey(nameof(CalendarItemID))]
        public CalendarItem CalendarItem { get; set; }



        [MaxLength(100)]
        public string DateDisplay { get; set; } // e.g., "15 أغسطس", "August 15"

    }



    // Timeline entity (Individual sessions)
    [Table("Timelines", Schema = "Calendar")]
    [Index(nameof(ID), nameof(CalendarItemID))]
    public class Timeline : EntityBase<long>
    {
        public long CalendarItemID { get; set; }

        [ForeignKey(nameof(CalendarItemID))]
        public CalendarItem CalendarItem { get; set; }

        public TimeSpan StartTime { get; set; } // e.g., 09:00
        public TimeSpan EndTime { get; set; } // e.g., 10:00
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<TimelineLocalization> TimelineLocalizations { get; set; }
    }

    // Timeline localization
    [Table("Timelines_Localization", Schema = "Calendar")]
    public class TimelineLocalization : BaseLocalization
    {
        public long TimelineID { get; set; }

        [ForeignKey(nameof(TimelineID))]
        public Timeline Timeline { get; set; }
    }
}
