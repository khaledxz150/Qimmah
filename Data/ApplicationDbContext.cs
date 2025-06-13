using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Qimmah.Data.configuration.localization;
using Qimmah.Data.configuration.System;
using Qimmah.Data.Localization;
using Qimmah.Data.System;
using Qimmah.Data.User;

namespace Qimmah.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users, IdentityRole<long>, long>
    {
        public override DbSet<Users> Users { set; get; }
        public DbSet<UserLocalization> UserLocalization { set; get; }
        public DbSet<Languages> Languages { set; get; }
        public DbSet<DictionaryLocalization> DictionaryLocalization { set; get; }
        public DbSet<Dictionary> Dictionary { set; get; }
        public DbSet<Lookup> Lookups { set; get; }
        public DbSet<LookupCategory> LookupsCategory { set; get; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Users");

            builder.ApplyConfiguration(new UserLocalization_Configuration());
            builder.ApplyConfiguration(new User_Configuration());
            builder.ApplyConfiguration(new LookupsCategoryConfiguration());

            builder.ApplyConfiguration(new LookupsConfiguration());

            builder.ApplyConfiguration(new CountrySeeding());

            new LocalizationConfigurations(builder);

            base.OnModelCreating(builder);
        }
    }
}
