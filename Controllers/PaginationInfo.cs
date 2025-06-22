namespace Qimmah.Controllers
{
    public class PaginationInfo
    {
        public int totalCount;
        public int currentPage;
        public int pageSize;
        public int currentlyViewingCount;

        public PaginationInfo(int totalCount, int currentPage, int pageSize, int currentlyViewingCount)
        {
            this.totalCount = totalCount;
            this.currentPage = currentPage;
            this.pageSize = pageSize;
            this.currentlyViewingCount = currentlyViewingCount;
        }
    }
}