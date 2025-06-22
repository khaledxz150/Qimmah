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

            // Seed Program Goals
            builder.Entity<ProgramGoal>().HasData(
                new ProgramGoal { Id = 1, ProgramId = 1 },
                new ProgramGoal { Id = 2, ProgramId = 1 },
                new ProgramGoal { Id = 3, ProgramId = 1 },
                new ProgramGoal { Id = 4, ProgramId = 1 },
                new ProgramGoal { Id = 5, ProgramId = 1 },
                new ProgramGoal { Id = 6, ProgramId = 1 },
                new ProgramGoal { Id = 7, ProgramId = 1 },
                new ProgramGoal { Id = 8, ProgramId = 1 }
            );

            builder.Entity<ProgramGoalLocalization>().HasData(
                // 1
                new ProgramGoalLocalization { ProgramGoalID = 1, LanguageID = 1, Description = "Enable participants in programming basics" },
                new ProgramGoalLocalization { ProgramGoalID = 1, LanguageID = 2, Description = "تمكين المشاركين من أساسيات البرمجة" },
                // 2
                new ProgramGoalLocalization { ProgramGoalID = 2, LanguageID = 1, Description = "Foster innovation in technical solutions" },
                new ProgramGoalLocalization { ProgramGoalID = 2, LanguageID = 2, Description = "تعزيز الابتكار في الحلول التقنية" },
                // 3
                new ProgramGoalLocalization { ProgramGoalID = 3, LanguageID = 1, Description = "Encourage teamwork and competition" },
                new ProgramGoalLocalization { ProgramGoalID = 3, LanguageID = 2, Description = "تحفيز روح العمل الجماعي والمنافسة" },
                // 4
                new ProgramGoalLocalization { ProgramGoalID = 4, LanguageID = 1, Description = "Connect participants with industry experts and mentors" },
                new ProgramGoalLocalization { ProgramGoalID = 4, LanguageID = 2, Description = "ربط المشاركين بأهل الصناعة والمستشارين" },
                // 5 (repeat of 2)
                new ProgramGoalLocalization { ProgramGoalID = 5, LanguageID = 1, Description = "Foster innovation in technical solutions" },
                new ProgramGoalLocalization { ProgramGoalID = 5, LanguageID = 2, Description = "تعزيز الابتكار في الحلول التقنية" },
                // 6 (repeat of 3)
                new ProgramGoalLocalization { ProgramGoalID = 6, LanguageID = 1, Description = "Encourage teamwork and competition" },
                new ProgramGoalLocalization { ProgramGoalID = 6, LanguageID = 2, Description = "تحفيز روح العمل الجماعي والمنافسة" },
                // 7 (repeat of 4)
                new ProgramGoalLocalization { ProgramGoalID = 7, LanguageID = 1, Description = "Connect participants with industry experts and mentors" },
                new ProgramGoalLocalization { ProgramGoalID = 7, LanguageID = 2, Description = "ربط المشاركين بأهل الصناعة والمستشارين" },
                // 8 (repeat of 1)
                new ProgramGoalLocalization { ProgramGoalID = 8, LanguageID = 1, Description = "Enable participants in programming basics" },
                new ProgramGoalLocalization { ProgramGoalID = 8, LanguageID = 2, Description = "تمكين المشاركين من أساسيات البرمجة" }
            );

            // Seed Program Components
            builder.Entity<ProgramComponent>().HasData(
                new ProgramComponent { Id = 1, ProgramId = 1 },
                new ProgramComponent { Id = 2, ProgramId = 1 },
                new ProgramComponent { Id = 3, ProgramId = 1 }
            );

            builder.Entity<ProgramComponentLocalization>().HasData(
                // Component 1
                new ProgramComponentLocalization { ProgramComponentID = 1, LanguageID = 1, Description = "Training sessions and workshops for programming languages, UI design, and startup tools" },
                new ProgramComponentLocalization { ProgramComponentID = 1, LanguageID = 2, Description = "جلسات تدريبية وورشات عمل لتعليم لغات برمجة، تصميم واجهات، وأدوات تطوير المشاريع الناشئة" },
                // Component 2
                new ProgramComponentLocalization { ProgramComponentID = 2, LanguageID = 1, Description = "Multi-day tech competition for creative solutions in teams, with prizes for top three" },
                new ProgramComponentLocalization { ProgramComponentID = 2, LanguageID = 2, Description = "مسابقة تقنية تمتد لعدة أيام لتطوير حلول تقنية إبداعية ضمن فرق، مع جوائز للمراكز الثلاثة الأولى" },
                // Component 3
                new ProgramComponentLocalization { ProgramComponentID = 3, LanguageID = 1, Description = "Building collaborative project platforms and interaction with visitors and mentors" },
                new ProgramComponentLocalization { ProgramComponentID = 3, LanguageID = 2, Description = "بناء منصات المشاريع المشتركة والتفاعل مع الزوار والمستشارين" }
            );
        }
    }
}
