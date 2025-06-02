using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Qimmah.Data.System;

namespace Qimmah.Data.Localization
{
    public class DictionaryLocalization
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int LanguageID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public Languages Language { get; set; }
        public Dictionary Dictionary { get; set; }

        public Lookup Lookup { get; set; }
        public ICollection<CompanyDictionaryLocalization> CompanyDictionaryLocalization { get; set; }
    }
}
