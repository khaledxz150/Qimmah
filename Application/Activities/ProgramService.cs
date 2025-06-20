using System.Globalization;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Qimmah.Core.Activities;
using Qimmah.Data;
using Qimmah.Models.Activities;
using Qimmah.Models.Common.Filters;
using Qimmah.Security;

namespace Qimmah.Application.Activities
{
    public class ProgramService : IProgramService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserPrinciple _CurrentUser;
        private readonly int _currentLanguageId;
        private readonly IMemoryCache _memoryCache;

        public ProgramService(ApplicationDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _CurrentUser = __CurrentUser;
            _currentLanguageId = _CurrentUser.LanguageID;
            _memoryCache = memoryCache;
        }

        public async Task<PaginatedList<ProgramCardViewModel>> GetProgramCardsAsync(int page, int pageSize)
        {
            var localization = _memoryCache.GetWord(_currentLanguageId, 234);
          
            var query = _context.Programs
                .Where(p => p.IsActive)
                .Select(p => new ProgramCardViewModel
                {
                    ID = p.ID,
                    Title = p.ProgramTitleLocalization
                        .Where(l => l.LanguageID == _currentLanguageId)
                        .Select(l => l.Description)
                        .FirstOrDefault(),
                    ShortDescription = p.ProgramDescriptionLocalization
                        .Where(l => l.LanguageID == _currentLanguageId)
                        .Select(l => l.Description)
                        .FirstOrDefault(),
                    IsCurrentlyBroadCasting =  p.IsCurrentlyBroadCasting,
                    ImageUrl = p.ImageUrl,
                    IsFree = p.IsFree,
                    PriceValue =  p.Price,
                    DiscountPercent = p.DiscountPercent,
                    DurationMinutes = p.DurationMinutes,
                    ParticipantCount = p.ParticipantCount,
                    Rating = p.Rating,
                    RatingCount = p.RatingCount,
                    FreeText = localization,
                    CategoryName = p.ProgramCategory.ProgramCategoryLocalizations
                        .Where(cl => cl.LanguageID == _currentLanguageId)
                        .Select(cl => cl.Description)
                        .FirstOrDefault()
                });

            var count = await query.CountAsync();
            var items = await query
                .OrderByDescending(p => p.ID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
            return new PaginatedList<ProgramCardViewModel>(items, count, page, pageSize);
        }

        public async Task<List<ProgramCardViewModel>> GetUserCurrentBroadCasts()
        {
            var currentLanguage = await _context.Languages
                .Where(l => l.ID == _currentLanguageId)
                .FirstOrDefaultAsync();

            if (currentLanguage == null)
                return new List<ProgramCardViewModel>();

            var freeText = _memoryCache.GetWord(_currentLanguageId, 234); // "مجاني"

            var query = _context.Programs
                .Where(p => p.Users.Select(u => u.Id).Contains(_CurrentUser.Code.Decrypt<long>()))
                .SelectMany(p => p.Sessions
                    .Where(s => s.IsActive && s.IsCurrentlyBroadcasting)
                    .Select(s => new ProgramCardViewModel
                    {
                        ID = p.ID,
                        Title = p.ProgramTitleLocalization
                            .Where(l => l.LanguageID == _currentLanguageId)
                            .Select(l => l.Description)
                            .FirstOrDefault(),
                        ShortDescription = p.ProgramDescriptionLocalization
                            .Where(l => l.LanguageID == _currentLanguageId)
                            .Select(l => l.Description)
                            .FirstOrDefault(),
                        ImageUrl = p.ImageUrl,
                        liveBrodcastLink = s.LiveBroadcastLink,
                        IsCurrentlyBroadCasting = s.IsCurrentlyBroadcasting,
                        IsFree = p.IsFree,
                        PriceValue = p.Price,
                        DiscountPercent = p.DiscountPercent,
                        DurationMinutes = p.DurationMinutes,
                        ParticipantCount = p.ParticipantCount,
                        Rating = p.Rating,
                        RatingCount = p.RatingCount,
                        CategoryName = p.ProgramCategory.ProgramCategoryLocalizations
                            .Where(cl => cl.LanguageID == _currentLanguageId)
                            .Select(cl => cl.Description)
                            .FirstOrDefault(),
                        SessionStartDateTime = s.StartDateTime,
                        SessionEndDateTime = s.EndDateTime
                    }));

            var results = await query.ToListAsync();

            foreach (var item in results)
            {
                item.FreeText = freeText;
                item.SessionDateTimeFormatted = FormatSessionDateTime(
                    item.SessionStartDateTime,
                    item.SessionEndDateTime,
                    currentLanguage.Culture
                );
            }

            return results;
        }

        public async Task<ProgramDetailsViewModel> GetProgramDetailsAsync(long programId)
        {
            var program = await _context.Programs
                .Where(p => p.ID == programId && p.IsActive)
                .Select(p => new ProgramDetailsViewModel
                {
                    ID = p.ID,
                    TitleAndShortDescription = p.ProgramTitleLocalization
                        .Where(l => l.LanguageID == _currentLanguageId)
                        .Select(l => new ProgramTitleDescriptionDTO (l.Description, l.ShortDescription ))
                        .FirstOrDefault(),
                    Description = p.ProgramDescriptionLocalization
                        .Where(l => l.LanguageID == _currentLanguageId)
                        .Select(l => l.Description)
                        .FirstOrDefault(),
                    ImageUrl = p.ImageUrl,
                    IsFree = p.IsFree,
                    Price = p.Price,
                    DiscountPercent = p.DiscountPercent,
                    DurationMinutes = p.DurationMinutes,
                    ParticipantCount = p.ParticipantCount,
                    Rating = p.Rating,
                    RatingCount = p.RatingCount,
                    CategoryName = p.ProgramCategory.ProgramCategoryLocalizations
                        .Where(cl => cl.LanguageID == _currentLanguageId)
                        .Select(cl => cl.Description)
                        .FirstOrDefault(),
                    OrganizerName = p.Organizer.OrganizerLocalizations.FirstOrDefault(x=>x.LanguageID == _currentLanguageId).Description,
                    OrganizerImage = p.Organizer.ImageUrl,
                    StartDate = p.StartDate,
                    Goals = p.ProgramGoals
                        .SelectMany(g => g.ProgramGoalLocalizations
                            .Where(gl => gl.LanguageID == _currentLanguageId)
                            .Select(gl => gl.GoalText))
                        .ToList(),
                    Components = p.ProgramComponents
                        .SelectMany(c => c.ProgramComponentLocalizations
                            .Where(cl => cl.LanguageID == _currentLanguageId)
                            .Select(cl => cl.ComponentText))
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return program;
        }

        private string FormatSessionDateTime(DateTime startDateTime, DateTime endDateTime, string culture)
        {
            var cultureInfo = new CultureInfo(culture);

            if (culture.StartsWith("ar"))
            {
                // Arabic formatting - EXACT format: "الأحد 17 أغسطس 2025 10:00 - 12:00 مساءً"
                string dayName = startDateTime.ToString("dddd", cultureInfo);
                string day = startDateTime.Day.ToString();
                string month = startDateTime.ToString("MMMM", cultureInfo);
                string year = startDateTime.Year.ToString();
                string startTime = startDateTime.ToString("HH:mm");
                string endTime = endDateTime.ToString("HH:mm");

                // Arabic AM/PM
                string amPm = endDateTime.Hour >= 12 ? "مساءً" : "صباحاً";

                return $"{dayName} {day} {month} {year} {startTime} - {endTime} {amPm}";
            }
            else
            {
                // English formatting - EXACT format: "Sunday 17 August 2025 10:00 - 12:00 PM"
                string dayName = startDateTime.ToString("dddd", cultureInfo);
                string day = startDateTime.Day.ToString();
                string month = startDateTime.ToString("MMMM", cultureInfo);
                string year = startDateTime.Year.ToString();
                string startTime = startDateTime.ToString("HH:mm");
                string endTime = endDateTime.ToString("HH:mm");

                // English AM/PM
                string amPm = endDateTime.Hour >= 12 ? "PM" : "AM";

                return $"{dayName} {day} {month} {year} {startTime} - {endTime} {amPm}";
            }
        }
    }
}
