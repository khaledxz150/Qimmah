using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Qimmah.Data.System;
using Qimmah.Enums.System;
using Qimmah.Data.Calendar;
using System.Reflection.Emit;

namespace Qimmah.Data.configuration.Calendar
{
    public class Calendar_Configurationcs
    {
        public Calendar_Configurationcs(ModelBuilder builder)
        {
            // Configure relationships
            #region CalendarItem
            builder.Entity<CalendarItem>()
               .HasMany(c => c.CalendarItemLocalizations)
               .WithOne(cl => cl.CalendarItem)
               .HasForeignKey(cl => cl.CalendarItemID)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CalendarItem>()
              .HasMany(c => c.Timelines)
          .WithOne(t => t.CalendarItem)
          .HasForeignKey(t => t.CalendarItemID)
          .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CalendarItemLocalization>().HasKey(x => new { x.LanguageID, x.CalendarItemID });


            builder.Entity<CalendarItem>().HasData(new List<CalendarItem>
            { new CalendarItem
                {
                    ID = 1,
                    EventDate = new DateTime(2024, 8, 15),
                    DayNumber = 1,
                    SortOrder = 1,
                    IsActive = true
                },
                new CalendarItem
                {
                    ID = 2,
                    EventDate = new DateTime(2024, 8, 16),
                    DayNumber = 2,
                    SortOrder = 2,
                    IsActive = true
                },
                new CalendarItem
                {
                    ID = 3,
                    EventDate = new DateTime(2024, 8, 17),
                    DayNumber = 3,
                    SortOrder = 3,
                    IsActive = true
                }});


            builder.Entity<CalendarItemLocalization>().HasData(new List<CalendarItemLocalization>
            {

            new CalendarItemLocalization { CalendarItemID = 1, LanguageID = 2, Description = "اليوم الأول", DateDisplay = "15 أغسطس" },
                new CalendarItemLocalization { CalendarItemID = 2, LanguageID = 2, Description = "اليوم الثاني", DateDisplay = "16 أغسطس" },
                new CalendarItemLocalization { CalendarItemID = 3, LanguageID = 2, Description = "اليوم الثالث", DateDisplay = "17 أغسطس" }
            });
            #endregion

            #region Timelines
            builder.Entity<Timeline>()
           .HasMany(t => t.TimelineLocalizations)
           .WithOne(tl => tl.Timeline)
           .HasForeignKey(tl => tl.TimelineID)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TimelineLocalization>().HasKey(x => new { x.LanguageID, x.TimelineID });


            builder.Entity<Timeline>().HasData(new List<Timeline>
            { new Timeline { ID = 1, CalendarItemID = 1, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 0, 0), SortOrder = 1, IsActive = true },
                new Timeline { ID = 2, CalendarItemID = 1, StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(10, 30, 0), SortOrder = 2, IsActive = true },
                new Timeline { ID = 3, CalendarItemID = 1, StartTime = new TimeSpan(10, 30, 0), EndTime = new TimeSpan(11, 30, 0), SortOrder = 3, IsActive = true },
                new Timeline { ID = 4, CalendarItemID = 1, StartTime = new TimeSpan(12, 0, 0), EndTime = new TimeSpan(13, 0, 0), SortOrder = 4, IsActive = true },
                new Timeline { ID = 5, CalendarItemID = 1, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(15, 0, 0), SortOrder = 5, IsActive = true },

                // Day 2 Sessions
                new Timeline { ID = 6, CalendarItemID = 2, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 30, 0), SortOrder = 1, IsActive = true },
                new Timeline { ID = 7, CalendarItemID = 2, StartTime = new TimeSpan(10, 30, 0), EndTime = new TimeSpan(12, 0, 0), SortOrder = 2, IsActive = true },
                new Timeline { ID = 8, CalendarItemID = 2, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(14, 30, 0), SortOrder = 3, IsActive = true },
                new Timeline { ID = 9, CalendarItemID = 2, StartTime = new TimeSpan(14, 30, 0), EndTime = new TimeSpan(16, 0, 0), SortOrder = 4, IsActive = true },

                // Day 3 Sessions
                new Timeline { ID = 10, CalendarItemID = 3, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(11, 0, 0), SortOrder = 1, IsActive = true },
                new Timeline { ID = 11, CalendarItemID = 3, StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(12, 30, 0), SortOrder = 2, IsActive = true },
                new Timeline { ID = 12, CalendarItemID = 3, StartTime = new TimeSpan(13, 30, 0), EndTime = new TimeSpan(15, 0, 0), SortOrder = 3, IsActive = true }});

            builder.Entity<TimelineLocalization>().HasData(new List<TimelineLocalization>() {

            new TimelineLocalization { TimelineID = 1, LanguageID = 2, Description = "الجلسة الافتتاحية - كلمة ترحيبية من رئيس القمة" },
                new TimelineLocalization { TimelineID = 2, LanguageID = 2, Description = "عرض فيديو تفاعلي \"رحلة التغيير العربي\"" },
                new TimelineLocalization { TimelineID = 3, LanguageID = 2, Description = "الجلسة الأولى: التحول الرقمي في العالم العربي" },
                new TimelineLocalization { TimelineID = 4, LanguageID = 2, Description = "حوار شبابي: أصوات من الميدان" },
                new TimelineLocalization { TimelineID = 5, LanguageID = 2, Description = "ورش عمل تطبيقية: كيف نبدأ مشروعك المبتكر؟" }
            });

            #endregion




            builder.Entity<Timeline>()
                .HasIndex(t => new { t.CalendarItemID, t.StartTime });
        }
    }
}
