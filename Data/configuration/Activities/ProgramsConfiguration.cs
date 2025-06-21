using Microsoft.EntityFrameworkCore;

using Qimmah.Data.Activities;
using Qimmah.Enums.System;

namespace Qimmah.Data.configuration.Activities
{
    public class ProgramsConfiguration
    {
        public ProgramsConfiguration(ModelBuilder builder)
        {
            builder.Entity<Programs>().HasKey(x => x.ID);
            builder.Entity<Programs>().HasOne(x => x.CityLookup).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Programs>().HasOne(x => x.CountryLookup).WithMany().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Sessions>().Property(x => x.IsActive).HasDefaultValue(false);
            builder.Entity<Sessions>().Property(x => x.IsCurrentlyBroadcasting).HasDefaultValue(false);


            // Seed Categories
            builder.Entity<ProgramCategory>().HasData(
                new ProgramCategory { ID = 1, IsActive = true, OrderID = 1 },
                new ProgramCategory { ID = 2, IsActive = true, OrderID = 2 }
            );

            builder.Entity<ProgramCategoryLocalization>().HasData(
                new ProgramCategoryLocalization
                {
                    ProgramCategoryID = 1,
                    LanguageID = 2, // Arabic
                    Description = "برمج"
                },
                new ProgramCategoryLocalization
                {
                    ProgramCategoryID = 2,
                    LanguageID = 2, // Arabic
                    Description = "الابتكار"
                }
            );

            // Seed Sessions for upcoming days
            var today = DateTime.Today;
            var baseTime = new TimeSpan(10, 0, 0); // 10:00 AM
            var sessionDuration = TimeSpan.FromHours(2); // 2 hours duration

            // Calculate total duration: 5 sessions × 2 hours = 10 hours = 600 minutes
            var totalDurationMinutes = 5 * (int)sessionDuration.TotalMinutes; // 5 sessions × 120 minutes = 600 minutes
            // Seed a Program
            builder.Entity<Programs>().HasData(
                new Programs
                {
                    ID = 1,
                    ImageUrl = "/images/programs/program1.jpg",
                    StartDate = new DateTime(2023, 7, 18),
                    DurationMinutes = 192, // 3h 12m
                    ParticipantCount = 30,
                    IsFree = true,
                    Price = null,
                    DiscountPercent = 100,
                    Rating = 4.7,
                    RatingCount = 128,
                    ProgramCategoryId = 1,
                    OrganizerId = 1,
                    IsActive = true,
                    CityLookupID = CitiesEnum.Amman.ToAnyType<int>(),
                    CountryLookupID = CountriesEnum.Jordan.ToAnyType<int>(),
                }
            );

            builder.Entity<Sessions>().HasData(
                // Today's session - Active and Broadcasting
                new Sessions
                {
                    ID = 1,
                    ProgramId = 1,
                    StartDateTime = today.Add(baseTime),
                    EndDateTime = today.Add(baseTime).Add(sessionDuration),
                    LiveBroadcastLink = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                    IsCurrentlyBroadcasting = true,
                    IsActive = true,
                    IsDeleted = false,
                },

                // Tomorrow's session
                new Sessions
                {
                    ID = 2,
                    ProgramId = 1,
                    StartDateTime = today.AddDays(1).Add(baseTime),
                    EndDateTime = today.AddDays(1).Add(baseTime).Add(sessionDuration),
                    LiveBroadcastLink = "https://www.youtube.com/watch?v=example2",
                    IsCurrentlyBroadcasting = false,
                    IsActive = false,
                    IsDeleted = false,
                },

                // Day after tomorrow
                new Sessions
                {
                    ID = 3,
                    ProgramId = 1,
                    StartDateTime = today.AddDays(2).Add(baseTime),
                    EndDateTime = today.AddDays(2).Add(baseTime).Add(sessionDuration),
                    LiveBroadcastLink = "https://www.youtube.com/watch?v=example3",
                    IsCurrentlyBroadcasting = false,
                    IsActive = false,
                   
                    IsDeleted = false,
                },

                // Next week - Monday
                new Sessions
                {
                    ID = 4,
                    ProgramId = 1,
                    StartDateTime = today.AddDays(7).Add(baseTime),
                    EndDateTime = today.AddDays(7).Add(baseTime).Add(sessionDuration),
                    LiveBroadcastLink = "https://www.youtube.com/watch?v=example4",
                    IsCurrentlyBroadcasting = false,
                    IsActive = false,
                    IsDeleted = false,
                },

                // Next week - Wednesday
                new Sessions
                {
                    ID = 5,
                    ProgramId = 1,
                    StartDateTime = today.AddDays(9).Add(baseTime),
                    EndDateTime = today.AddDays(9).Add(baseTime).Add(sessionDuration),
                    LiveBroadcastLink = "https://www.youtube.com/watch?v=example5",
                    IsCurrentlyBroadcasting = false,
                    IsActive = false,
                    IsDeleted = false,
                }
            );
            // Seed Program Title Localization (Arabic)
            builder.Entity<ProgramTitleLocalization>().HasData(
                new ProgramTitleLocalization
                {
                    ProgramID = 1,
                    LanguageID = 2, // Arabic
                    Description = "برمج. ابتكر. انطلق",
                    ShortDescription = "فعالية تفاعلية تجمع بين التدريب العملي، الإرشاد المهني، وفرص بناء تطبيقات ومشاريع تقنية حقيقية بمساعدة خبراء في المجال."
                }
            );

            // Seed Program Description Localization (Arabic)
            builder.Entity<ProgramDescriptionLocalization>().HasData(
                new ProgramDescriptionLocalization
                {
                    ProgramID = 1,
                    LanguageID = 2, // Arabic
                    Description = "برمج. ابتكر. انطلق.\" ليست مجرد فعالية تقنية، بل منصة متكاملة تُطلق العنان لإبداع الشباب، وتمنحهم فرصة حقيقية للانتقال من مجرد أفكار إلى مشاريع واقعية ذات أثر.\r\n\r\n يعيش المشاركون تجربة فريدة تجمع بين التعلم العملي، والتفكير التصميمي، والعمل الجماعي، ضمن بيئة تفاعلية تحفّز الابتكار وتحتضن الموهبة. سواء كنت مبتدئًا في البرمجة أو مطورًا يسعى للارتقاء بمهاراته، ستجد في هذه الفعالية محتوى يناسبك، وورشًا تُشعل شغفك، وفرصًا لصقل مشروعك."
                }
            );
        }
    }
}
