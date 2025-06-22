using System.Collections.Immutable;
using System.Globalization;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Qimmah.Core.Activities;
using Qimmah.Data;
using Qimmah.Data.Activities;
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

        public async Task<PaginatedList<ProgramCardViewModel>> GetProgramCardsAsync(
     int page,
     int pageSize,
     string search = "",
     string orderBy = "1",
     string categories = "")
        {
            var localization = _memoryCache.GetWord(_currentLanguageId, 234);

            var query = _context.Programs
                .Where(p => p.IsActive)
                .AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p =>
                    p.ProgramTitleLocalization
                        .Any(l => l.LanguageID == _currentLanguageId && l.Description.Contains(search)) ||
                    p.ProgramDescriptionLocalization
                        .Any(l => l.LanguageID == _currentLanguageId && l.Description.Contains(search)));
            }

            // Apply category filter
            if (!string.IsNullOrWhiteSpace(categories))
            {
                var categoryIds = categories.Split(',')
                    .Where(c => int.TryParse(c.Trim(), out _))
                    .Select(c => int.Parse(c.Trim()))
                    .ToList();

                if (categoryIds.Any())
                {
                    query = query.Where(p => categoryIds.Contains(p.ProgramCategoryId));
                }
            }

            // Apply ordering
            query = ApplyOrdering(query, orderBy);

            // Project to view model
            var projectedQuery = query.Select(p => new ProgramCardViewModel
            {
                Code = p.ID.Encrypt(),
                Title = p.ProgramTitleLocalization
                    .Where(l => l.LanguageID == _currentLanguageId)
                    .Select(l => l.Description)
                    .FirstOrDefault(),
                ShortDescription = p.ProgramDescriptionLocalization
                    .Where(l => l.LanguageID == _currentLanguageId)
                    .Select(l => l.Description)
                    .FirstOrDefault(),
                IsCurrentlyBroadCasting = p.IsCurrentlyBroadCasting,
                ImageUrl = p.ImageUrl,
                IsFree = p.IsFree,
                PriceValue = p.Price,
                DiscountPercent = p.DiscountPercent,
                DurationMinutes = p.DurationMinutes,
                ParticipantCount = p.ParticipantCount,
                Rating = p.Rating, 
                RatingCount = p.RatingCount,
                FreeText = localization,
                CategoryName = p.ProgramCategory.ProgramCategoryLocalizations
                    .Where(cl => cl.LanguageID == _currentLanguageId)
                    .Select(cl => cl.Description)
                    .FirstOrDefault(),
            });

            var count = await projectedQuery.CountAsync();
            var items = await projectedQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return new PaginatedList<ProgramCardViewModel>(items, count, page, pageSize);
        }

        private IQueryable<Programs> ApplyOrdering(IQueryable<Programs> query, string orderBy)
        {
            return orderBy switch
            {
                "1" => query.OrderByDescending(p => p.ID), // Default - Latest first
                "2" => query.OrderByDescending(p => p.StartDate), // Newest by date
                "3" => query.OrderBy(p => p.StartDate), // Oldest by date
                "4" => query.OrderByDescending(p => p.Rating), // Highest rated first
                "5" => query.OrderBy(p => p.Rating), // Lowest rated first
                "6" => query.OrderByDescending(p => p.ParticipantCount), // Most popular first
                "7" => query.OrderBy(p => p.Price), // Cheapest first
                "8" => query.OrderByDescending(p => p.Price), // Most expensive first
                "9" => query.OrderBy(p => p.ProgramTitleLocalization
                    .Where(l => l.LanguageID == _currentLanguageId)
                    .Select(l => l.Description)
                    .FirstOrDefault()), // A-Z by title
                "10" => query.OrderByDescending(p => p.ProgramTitleLocalization
                    .Where(l => l.LanguageID == _currentLanguageId)
                    .Select(l => l.Description)
                    .FirstOrDefault()), // Z-A by title
                "11" => query.OrderByDescending(p => p.DurationMinutes), // Longest first
                "12" => query.OrderBy(p => p.DurationMinutes), // Shortest first
                _ => query.OrderByDescending(p => p.ID) // Default fallback
            };
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
                        Code = p.ID.Encrypt(),
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
            var freeText = _memoryCache.GetWord(_currentLanguageId, 253); // "Watch Here"
            var currentLanguage = await _context.Languages
              .Where(l => l.ID == _currentLanguageId)
              .FirstOrDefaultAsync();
            var program = await _context.Programs
                .Where(p => p.ID == programId && p.IsActive)
                .Select(p => new ProgramDetailsViewModel
                {
                    ID = p.ID,
                    TitleAndShortDescription = p.ProgramTitleLocalization
                        .Where(l => l.LanguageID == _currentLanguageId)
                        .Select(l => new ProgramTitleDescriptionDTO(l.Description, l.ShortDescription))
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
                    OrganizerName = p.Organizer.OrganizerLocalizations.FirstOrDefault(x => x.LanguageID == _currentLanguageId).Description,
                    OrganizerImage = p.Organizer.ImageUrl,
                    StartDate = p.StartDate,
                    Goals = p.ProgramGoals
                        .SelectMany(g => g.ProgramGoalLocalizations
                            .Where(gl => gl.LanguageID == _currentLanguageId)
                            .Select(gl => gl.Description))
                        .ToList(),
                    Components = p.ProgramComponents
                        .SelectMany(c => c.ProgramComponentLocalizations
                            .Where(cl => cl.LanguageID == _currentLanguageId)
                            .Select(cl => cl.Description))
                        .ToList(),
                    SessionsOriginal = p.Sessions.Select(x=>x).ToList()
                })
                .FirstOrDefaultAsync();

            foreach (var x in program.SessionsOriginal)
            {

                program.Sessions.Add($"{FormatSessionDateTimeV2(x.StartDateTime, x.EndDateTime, currentLanguage.Culture)}  {$"{(x.LiveBroadcastLink != null && x.IsActive == true && x.IsCurrentlyBroadcasting == false ? $"<a href='{x.LiveBroadcastLink}' class='btn btn-primary p-3 ms-3' target='_blank'>{freeText}</a>" : "")}"}");
            }

            return program;
        }
        public async Task<List<ProgramCategoryViewModel>> GetCategoriesAsync()
        {
            return await _context.ProgramCategories
                .Where(c => c.IsActive)
                .Select(c => new ProgramCategoryViewModel
                {
                    Code = c.ID,
                    Name = c.ProgramCategoryLocalizations
                        .Where(l => l.LanguageID == _currentLanguageId)
                        .Select(l => l.Description)
                        .FirstOrDefault()
                })
                .ToListAsync();
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

        private string FormatSessionDateTimeV2(DateTime startDateTime, DateTime endDateTime, string culture)
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

                return $"{dayName} {day} {month} {year} - {startTime} - {endTime} {amPm}";
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
