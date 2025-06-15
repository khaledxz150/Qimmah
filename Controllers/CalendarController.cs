using Microsoft.AspNetCore.Mvc;

namespace Qimmah.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
