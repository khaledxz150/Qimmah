using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Qimmah.Data.Activities;
using Qimmah.Data.Calendar;
using Qimmah.Data.configuration.Activities;
using Qimmah.Data.configuration.Calendar;
using Qimmah.Data.configuration.localization;
using Qimmah.Data.configuration.Organizer;
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

        public DbSet<CalendarItem> CalendarItems { get; set; }
        public DbSet<CalendarItemLocalization> CalendarItemLocalizations { get; set; }
        public DbSet<Timeline> Timelines { get; set; }
        public DbSet<TimelineLocalization> TimelineLocalizations { get; set; }

        public DbSet<Programs> Programs { get; set; }
        public DbSet<Qimmah.Data.Organizer.Organizer> Organizer { get; set; }
        public DbSet<Sessions> Sessions { get; set; }



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


            new LocalizationConfigurations(builder);
            new Calendar_Configurationcs(builder);
            new OrganizerConfiguration(builder);
            new ProgramsConfiguration(builder);

            base.OnModelCreating(builder);
        }
    }
}
