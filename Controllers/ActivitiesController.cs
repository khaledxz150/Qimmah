using Microsoft.AspNetCore.Mvc;

using Qimmah.Core.Activities;

namespace Qimmah.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly IProgramService programService;

        public ActivitiesController(IProgramService programService)
        {
            this.programService = programService;
        }

        public async Task<IActionResult> Index()
        {

           
            return View();
        
        
        
        
        
        }


        public async Task<IActionResult> GetPrograms()
        {
            return PartialView("~/Views/Shared/Components/ProgramCardComponents/_ProgramCards.cshtml", await programService.GetProgramCardsAsync(1,9));
        }
    }
}
