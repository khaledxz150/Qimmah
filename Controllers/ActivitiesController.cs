using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Qimmah.Attributes.FilterAttributes;
using Qimmah.Core.Activities;
using Qimmah.DTOs.Activities;
using Qimmah.Enums.Navigation;
using Qimmah.Models.Activities;
using Qimmah.Models.Common.Filters;
using Qimmah.Models.Common.Pagination;

using static Qimmah.DTOs.Activities.ProgramRatingDto;

namespace Qimmah.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly IProgramService programService;
        private readonly IProgramRatingService _ratingService;
        public ActivitiesController(IProgramService programService, IProgramRatingService ratingService)
        {
            this.programService = programService;
            _ratingService = ratingService;
        }
        #region Program
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
                return ViewComponent("ProgramCardComponents", new { obj = request.Items });
            }
            catch (Exception ex)
            {
                return PartialView("~/Views/Shared/_Error.cshtml", new { Message = "حدث خطأ في عرض البرامج" });
            }
        }
        public class RenderCardsRequest
        {
            public List<ProgramCardViewModel> Items { get; set; }
        }


        // Render pagination using the provided data
        [HttpPost]
        public IActionResult RenderPagination([FromBody] RenderPaginationRequest request)
        {
            try
            {
                var paginationInfo = new Qimmah.Models.Common.Filters.PaginationInfo(request.TotalCount, request.CurrentPage, request.PageSize, request.CurrentlyViewingCount);
                return PartialView("~/Views/Shared/CommonViews/_Pagination.cshtml", paginationInfo);
            }
            catch (Exception ex)
            {
                return PartialView("~/Views/Shared/_Error.cshtml", new { Message = "حدث خطأ في عرض الصفحات" });
            }
        }
        [ActiveTab(TabOptions.Activities)]
        public async Task<IActionResult> ProgramDetails(string ProgramCode)
        {
            return View( await programService.GetProgramDetailsAsync(ProgramCode.Decrypt<long>()));
        }


        #endregion

        #region Ratings
        [HttpPost("{programId}/rate")]
        [Authorize]
        public async Task<IActionResult> RateProgram(long programId, [FromBody] RateProgramRequest request)
        {
            var userId = __CurrentUser.Code.Decrypt<long>();

            var success = await _ratingService.RateProgramAsync(programId, userId, request.Rating, request.ReviewText);

            if (success)
                return Ok(new { message = "Rating submitted successfully" });

            return BadRequest(new { message = "Failed to submit rating" });
        }

        [HttpGet("{programId}/ratings")]
        public async Task<IActionResult> GetProgramRatings(long programId, int page = 1, int pageSize = 10)
        {
            var ratings = await _ratingService.GetProgramRatingsAsync(programId, page, pageSize);
            return Ok(ratings);
        }

        [HttpGet("{programId}/stats")]
        public async Task<IActionResult> GetRatingStats(long programId)
        {
            var stats = await _ratingService.GetProgramRatingStatsAsync(programId);
            return Ok(stats);
        }

        [HttpGet("{programId}/my-rating")]
        [Authorize]
        public async Task<IActionResult> GetMyRating(long programId)
        {
            var userId = __CurrentUser.Code.Decrypt<long>();
            var rating = await _ratingService.GetUserRatingAsync(programId, userId);
            return Ok(rating);
        }
        #endregion
    }
}