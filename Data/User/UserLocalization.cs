﻿using System.ComponentModel.DataAnnotations.Schema;

using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Qimmah.Data.Base;

namespace Qimmah.Data.User
{
    [Table("Users_Localization")]
    public class UserLocalization : BaseLocalization
    {
        public long UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users Users { get; set; }
    }

    public class UserLocalization_Configuration : IEntityTypeConfiguration<UserLocalization>
    {
        public void Configure(EntityTypeBuilder<UserLocalization> builder)
        {
            builder.HasKey(x => new { x.LanguageID, x.UserID });
            builder.HasOne<Users>().WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
