using Qimmah.Enums.Navigation;

namespace Qimmah.Models.Calendar
{
    public class CalendarItemViewModel
    {
        public long Id { get; set; }
        public int DayNumber { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string DateDisplay { get; set; }
        public List<TimelineViewModel> Timelines { get; set; } = new();
        public ViewTypeEnum ViewTypeEnum { get; set; } = ViewTypeEnum.LandingPage;
    }

}
