using System.ComponentModel.DataAnnotations.Schema;

using Qimmah.Data.Base;
using Qimmah.Data.Localization;

namespace Qimmah.Data.System
{
    public class Lookup : EntityBase<int>
    {
        public int CategoryID { get; set; }

        public string Description { get; set; }

        public int? DictionaryID { get; set; } = null;

        public int? ParentID { get; set; }

        public int? IntValue { get; set; }

        public long? LongValue { get; set; }

        public string? StringValue { get; set; } = null;

        public bool? BoolValue { get; set; }

        public Guid? GuidValue { get; set; }

        public int OrderID { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public LookupCategory LookupCategory { get; set; }

        [ForeignKey(nameof(ParentID))]
        public Lookup ParentLookup { get; set; }

        [ForeignKey(nameof(DictionaryID))]
        public Dictionary Dictionary { get; set; }
    }

    public class LookupCategory : EntityBase<int>
    {

        public string Description { get; set; }
        public int? ParentID { get; set; }
        public int OrderID { get; set; }
        public ICollection<Lookup> Lookup { get; set; }
    }
}
