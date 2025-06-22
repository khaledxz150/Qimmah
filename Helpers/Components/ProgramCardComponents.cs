using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Qimmah.Core.Activities;
using Qimmah.Models.Activities;

namespace Qimmah.Helpers.Components
{
    public class ProgramCardComponents : ViewComponent
    {
        private readonly IProgramService programService;
        public ProgramCardComponents(IProgramService programService)
        {
            this.programService = programService;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<ProgramCardViewModel> obj,int size = 3)
        {
            if (obj.IsNotNullOrEmpty())
            {
                return View("_ProgramCards", obj);

            }
            return View("_ProgramCards", (await programService.GetProgramCardsAsync(1, size)).Items);
        }
    }
}
