using System.ComponentModel.DataAnnotations.Schema;

using Qimmah.Data.Base;

namespace Qimmah.Data.Activities
{
    [Table("Sessions", Schema = "Activities")]
    public class Sessions : EntityBase<long>
    {
        public long ProgramId { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public Programs Program { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public string LiveBroadcastLink { get; set; }
        public bool IsCurrentlyBroadcasting { get; set; }

        // Only one session can be active per program
        public bool IsActive { get; set; }
    }
}
