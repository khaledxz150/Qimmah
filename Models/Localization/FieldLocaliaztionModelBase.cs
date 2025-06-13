namespace Qimmah.Models.Localization
{
    public class FieldLocaliaztionModelBase
    {
        public string Code { get; set; }
        public string LanguageName { get; set; }
        public object Locale { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
    }
}
