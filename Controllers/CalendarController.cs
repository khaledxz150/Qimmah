using Microsoft.AspNetCore.Mvc;

using Qimmah.Attributes.FilterAttributes;
using Qimmah.Enums.Navigation;

namespace Qimmah.Controllers
{
    public class CalendarController : Controller
    {
        [ActiveTab(TabOptions.Calendar)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
