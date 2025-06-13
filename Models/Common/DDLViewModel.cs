namespace Qimmah.Models.Common
{
    public class DDLViewModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public int SpareInt { get; set; }
        public string SpareString { get; set; }
    }


    public class DDLAPIModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameAndNumber { get; set; }
    }

    public class ListDDLAPIModel
    {
        public List<DDLAPIModel> DisposalPoints { get; set; }
        public List<DDLAPIModel> OvernightPoints { get; set; }
        public List<DDLAPIModel> Days { get; set; }
    }
}