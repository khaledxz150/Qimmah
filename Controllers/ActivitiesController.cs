using Microsoft.AspNetCore.Mvc;

using Qimmah.Models.Activities;

namespace Qimmah.Controllers
{
    public class ActivitiesController : Controller
    {
        public IActionResult Index()
        {
            var programs = new List<ProgramCardViewModel>
            {
                new ProgramCardViewModel
                {
                    ImageUrl = "https://picsum.photos/200/300",
                    Type = "برنامج",
                    Title = "برنامج ابتكار انطلق",
                    Description = "منصة تدريبية لتطوير الأعمال الناشئة في الشرق الأوسط",
                    PriceLabel = "مجاني",
                    Duration = "8h 12m",
                    ParticipantCount = "30 أعضاء"
                },
                new ProgramCardViewModel
                {
                    ImageUrl = "https://picsum.photos/200/300",
                    Type = "برنامج",
                    Title = "برنامج ابتكار انطلق",
                    Description = "منصة تدريبية لتطوير الأعمال الناشئة في الشرق الأوسط",
                    PriceLabel = "مجاني",
                    Duration = "8h 12m",
                    ParticipantCount = "30 أعضاء"
                },
                new ProgramCardViewModel
                {
                    ImageUrl = "https://picsum.photos/200/300",
                    Type = "برنامج",
                    Title = "برنامج ابتكار انطلق",
                    Description = "منصة تدريبية لتطوير الأعمال الناشئة في الشرق الأوسط",
                    PriceLabel = "مجاني",
                    Duration = "8h 12m",
                    ParticipantCount = "30 أعضاء"
                }
            };

            return PartialView("_ProgramCards", programs);
            return View(programs);
        }
    }
}
