using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qimmah.Data.Localization
{
    public class CompanyDictionaryLocalization
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int LanguageID { get; set; }
        
        [Required]
        public long TenantID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public Languages Language { get; set; }
        public Dictionary Dictionary { get; set; }
        public DictionaryLocalization DictionaryLocalization { get; set; }
    }
}
