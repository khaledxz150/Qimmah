namespace Qimmah.Models.Calendar
{
    public class TimelineViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string TimeDisplay { get; set; }
    }
}
