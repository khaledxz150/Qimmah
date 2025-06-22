using Microsoft.AspNetCore.Mvc;

using Qimmah.Attributes.FilterAttributes;
using Qimmah.Core.Activities;
using Qimmah.Enums.Navigation;
using Qimmah.Models.Activities;
using Qimmah.Models.Common.Filters;

namespace Qimmah.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly IProgramService programService;

        public ActivitiesController(IProgramService programService)
        {
            this.programService = programService;
        }
        [ActiveTab(TabOptions.Activities)]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 9, string search = "", string orderBy = "1", string categories = "")
        {
            var programs = await GetPrograms(page, pageSize, search, orderBy, categories);
            return View(programs);
        }

        public async Task<PaginatedList<ProgramCardViewModel>> GetPrograms(int pageIndex, int pageSize, string search = "", string orderBy = "1", string categories = "")
        {
            return await programService.GetProgramCardsAsync(pageIndex, pageSize, search, orderBy, categories);
        }

        // Single request to get the data
        [HttpPost]
        public async Task<IActionResult> GetProgramData(int page = 1, int pageSize = 9, string search = "", string orderBy = "1", string categories = "")
        {
            try
            {
                var programs = await GetPrograms(page, pageSize, search, orderBy, categories);

                return Json(new
                {
                    success = true,
                    data = programs,
                    metadata = new
                    {
                        totalCount = programs.TotalCount,
                        currentPage = programs.PageIndex,
                        totalPages = (int)Math.Ceiling((double)programs.TotalCount / programs.PageSize),
                        pageSize = programs.PageSize,
                        startItem = (programs.PageIndex - 1) * programs.PageSize + 1,
                        endItem = Math.Min(programs.PageIndex * programs.PageSize, programs.TotalCount),
                        currentlyViewingCount = programs.Items.Count
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "حدث خطأ في تحميل البيانات",
                    error = ex.Message
                });
            }
        }

        // Render cards using the provided data
        [HttpPost]
        public IActionResult RenderProgramCards([FromBody] RenderCardsRequest request)
        {
            try
            {
                return ViewComponent("ProgramCardComponents", new { obj = request.Items});
            }
            catch (Exception ex)
            {
                return PartialView("~/Views/Shared/_Error.cshtml", new { Message = "حدث خطأ في عرض البرامج" });
            }
        }

        // Render pagination using the provided data
        [HttpPost]
        public IActionResult RenderPagination([FromBody] RenderPaginationRequest request)
        {
            try
            {
                var paginationInfo = new PaginationInfo(request.TotalCount, request.CurrentPage, request.PageSize, request.CurrentlyViewingCount);
                return PartialView("~/Views/Shared/CommonViews/_Pagination.cshtml", paginationInfo);
            }
            catch (Exception ex)
            {
                return PartialView("~/Views/Shared/_Error.cshtml", new { Message = "حدث خطأ في عرض الصفحات" });
            }
        }
    }

    // Request models for rendering
    public class RenderCardsRequest
    {
        public List<ProgramCardViewModel> Items { get; set; }
    }

    public class RenderPaginationRequest
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int CurrentlyViewingCount { get; set; }

    }
}