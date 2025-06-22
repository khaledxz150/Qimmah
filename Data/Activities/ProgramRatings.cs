using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using Qimmah.Data.Base;

namespace Qimmah.Data.Activities
{
    [Table("ProgramRatings", Schema = "Activities")]
    [Index(nameof(UserId), nameof(ProgramId), IsUnique = true)]
    public class ProgramRating : EntityBase<long>
    {
        public long ProgramId { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public Programs Program { get; set; }

        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User.Users User { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        // Optional review text (for future full review system)
        [MaxLength(1000)]
        public string ReviewText { get; set; }

        public DateTime RatedAt { get; set; } = DateTime.UtcNow;

        // For future features
        public bool IsVerifiedPurchase { get; set; }
        public int HelpfulCount { get; set; } = 0;
        public bool IsReported { get; set; }
        public DateTime? UpdatedAt { get;  set; }
        public DateTime? CreatedAt { get; set; }
    }

}