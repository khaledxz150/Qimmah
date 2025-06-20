using Microsoft.AspNetCore.Mvc;

using Qimmah.Core.Activities;

namespace Qimmah.Helpers.Components
{
    public class LiveBroadcastComponent : ViewComponent
    {
        private readonly IProgramService? programService;

        public LiveBroadcastComponent(IProgramService? programService)
        {
            this.programService = programService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await programService.GetUserCurrentBroadCasts();
            return View("_liveBroadcast", data);
        }
    }
}
