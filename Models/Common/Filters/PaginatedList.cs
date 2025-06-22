namespace Qimmah.Models.Common.Filters
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; }
        public int TotalCount { get; }
        public int PageIndex { get; }
        public int PageSize { get; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            TotalCount = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }


    public class PaginationInfo
    {
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int CurrentlyViewingCount { get;  set; }

        public PaginationInfo(int totalCount, int pageIndex, int pageSize,int CurrentlyViewingCount)
        {
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
            this.CurrentlyViewingCount = CurrentlyViewingCount;
        }

        // Create from PaginatedList
        public static PaginationInfo FromPaginatedList<T>(PaginatedList<T> paginatedList)
        {
            return new PaginationInfo(paginatedList.TotalCount, paginatedList.PageIndex, paginatedList.PageSize, paginatedList.Items.Count);
        }
    }

}
