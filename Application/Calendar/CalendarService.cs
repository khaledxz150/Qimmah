using Microsoft.EntityFrameworkCore;

using Qimmah.Core.Calendar;
using Qimmah.Data;
using Qimmah.Models.Calendar;

namespace Qimmah.Application.Calendar
{
    public class CalendarService : ICalendarService
    {
        private readonly ApplicationDbContext _context;
        private readonly int _currentLanguageId;

        public CalendarService(ApplicationDbContext context)
        {
            _context = context;
            _currentLanguageId = __CurrentUser.LanguageID;
        }

        public async Task<List<CalendarItemViewModel>> GetCalendarItemsAsync()
        {
            
            return await _context.CalendarItems
      .Where(c => c.IsActive)
      .Include(c => c.CalendarItemLocalizations)
      .Include(c => c.Timelines)
          .ThenInclude(t => t.TimelineLocalizations)
      .OrderBy(c => c.SortOrder)
      .Select(c => new CalendarItemViewModel
      {
          Id = c.ID,
          DayNumber = c.DayNumber,
          EventDate = c.EventDate,
          Description = c.CalendarItemLocalizations
              .Where(cl => cl.LanguageID == _currentLanguageId)
              .FirstOrDefault().Description,
          DateDisplay = c.CalendarItemLocalizations
              .Where(cl => cl.LanguageID == _currentLanguageId)
              .FirstOrDefault().DateDisplay,
          Timelines = c.Timelines
              .Where(t => t.IsActive)
              .OrderBy(t => t.SortOrder)
              .Select(t => new TimelineViewModel
              {
                  Id = t.ID,
                  Description = t.TimelineLocalizations
                      .Where(tl => tl.LanguageID == _currentLanguageId)
                      .FirstOrDefault().Description,
                  StartTime = t.StartTime,
                  EndTime = t.EndTime,
                  TimeDisplay = $"{t.StartTime:hh\\:mm} – {t.EndTime:hh\\:mm}"
              }).ToList()
      })
      .AsNoTracking()
      .ToListAsync();
        }
    }
}
