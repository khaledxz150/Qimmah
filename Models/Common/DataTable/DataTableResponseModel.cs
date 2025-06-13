namespace Qimmah.Models.Common.DataTable
{
    public class DataTableResponseModel<T>
    {
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public List<T> aaData { get; set; }
    }
}
