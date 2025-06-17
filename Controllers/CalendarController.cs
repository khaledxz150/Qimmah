using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Qimmah.Attributes.FilterAttributes;
using Qimmah.Core.Calendar;
using Qimmah.Enums.Navigation;

namespace Qimmah.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarService? _calendarService;

        public CalendarController(ICalendarService? calendarService)
        {
            _calendarService = calendarService;
        }

        [ActiveTab(TabOptions.Calendar)]
        public async Task<IActionResult> Index()
        {
            var xx = __CurrentUser;
            var calendarItems = await _calendarService.GetCalendarItemsAsync();

            return View(calendarItems);
        }
    }
}
