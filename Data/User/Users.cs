using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Qimmah.Data.Activities;


namespace Qimmah.Data.User
{
    [Microsoft.EntityFrameworkCore.Index(nameof(Id), nameof(LanguageID))]
    public class Users : IdentityUser<long>
    {
        [Column(Order = 2)]
        public int LanguageID { get; set; }

        [ForeignKey("LanguageID")]
        public Localization.Languages Language { get; set; }
        public ICollection<UserLocalization> UserLocalizations { get; set; }
        public ICollection<Programs> programs { get; set; }
    }

    public class User_Configuration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasMany<UserLocalization>().WithOne().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
