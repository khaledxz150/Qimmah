using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Qimmah.Models.Activities;

namespace Qimmah.Helpers.Components
{
    public class ProgramCardComponents : ViewComponent
    {
        //private DbContextOptions<MyContext> db = new DbContextOptions<MyContext>();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("_ProgramCards", new List<ProgramCardViewModel>
            {
                new ProgramCardViewModel
                {
                    ImageUrl = "/images/programs/program1.jpg",
                    Type = "برنامج",
                    Title = "برنامج ابتكار انطلق",
                    Description = "منصة تدريبية لتطوير الأعمال الناشئة في الشرق الأوسط",
                    PriceLabel = "مجاني",
                    Duration = "8h 12m",
                    ParticipantCount = "30 أعضاء"
                },
                new ProgramCardViewModel
                {
                    ImageUrl = "/images/programs/program2.jpg",
                    Type = "برنامج",
                    Title = "برنامج ابتكار انطلق",
                    Description = "منصة تدريبية لتطوير الأعمال الناشئة في الشرق الأوسط",
                    PriceLabel = "مجاني",
                    Duration = "8h 12m",
                    ParticipantCount = "30 أعضاء"
                },
                new ProgramCardViewModel
                {
                    ImageUrl = "/images/programs/program3.jpg",
                    Type = "برنامج",
                    Title = "برنامج ابتكار انطلق",
                    Description = "منصة تدريبية لتطوير الأعمال الناشئة في الشرق الأوسط",
                    PriceLabel = "مجاني",
                    Duration = "8h 12m",
                    ParticipantCount = "30 أعضاء"
                }
            });
        }
    }
}
