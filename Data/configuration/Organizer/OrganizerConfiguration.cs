namespace Qimmah.Data.configuration.Organizer
{
    using Microsoft.EntityFrameworkCore;

    using Qimmah.Data.Activities;
    using Qimmah.Data.Organizer;

    public class OrganizerConfiguration
    {
        public OrganizerConfiguration(ModelBuilder builder)
        {
            // Seed Organizer
            builder.Entity<Organizer>().HasData(
                new Organizer
                {
                    ID = 1,
                    ImageUrl = "/images/organizers/organizer1.jpg",
                    Email = "info@qimmah.org",
                    Phone = "+962-6-1234567",
                    Website = "https://qimmah.org",
                    IsActive = true,
                }
            );

            // Seed Organizer Localization - Arabic
            builder.Entity<OrganizerLocalization>().HasData(
                new OrganizerLocalization
                {
                    OrganizerId = 1,
                    LanguageID = 1, // Arabic
                    Description = "مؤسسة قمة",
                }
            );

            // Seed Organizer Localization - English
            builder.Entity<OrganizerLocalization>().HasData(
                new OrganizerLocalization
                {
                    OrganizerId = 1,
                    LanguageID = 2, // English
                    Description = "Qimmah Foundation",
                }
            );
        }
    }
}
