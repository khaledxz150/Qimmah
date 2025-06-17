using Qimmah.Models.Calendar;

namespace Qimmah.Core.Calendar
{
    public interface ICalendarService
    {
        Task<List<CalendarItemViewModel>> GetCalendarItemsAsync();
    }
}
