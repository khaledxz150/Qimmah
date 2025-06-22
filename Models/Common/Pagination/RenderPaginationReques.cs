namespace Qimmah.Models.Common.Pagination
{
    public class RenderPaginationRequest
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int CurrentlyViewingCount { get; set; }

    }
}
