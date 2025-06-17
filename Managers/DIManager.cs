using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using Qimmah.Application.Calendar;
using Qimmah.Application.System;
using Qimmah.Core.Calendar;
using Qimmah.Core.System;
using Qimmah.Data;
using Qimmah.Data.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using static Qimmah.Managers.JWTManager;

namespace Qimmah.Managers
{
    public static class DIManager
    {
        public static void InjectDB(this IServiceCollection Services, string CS)
        {
            Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(CS));

        }

        public static void InjectIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure Identity
            services.AddIdentity<Users, IdentityRole<long>>(options =>
            {
                // Password requirements
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                // Email confirmation (optional)
                // options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // Cookie Authentication
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";

                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;

                // (Optional) Security settings
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Use Always in production (HTTPS)
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.Name = ".App.Auth";
            });

            // Optional: Add role/claim-based policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            });
        }


        public static void InjectServices(this IServiceCollection Services)
        {
            Services.AddScoped<ILookupService, LookupService>();
            Services.AddScoped<ICalendarService, CalendarService>();

        }
    }
    public class CustomJwtSecurityTokenHandler : JwtSecurityTokenHandler
    {
        private readonly ISecurityTokenValidator _tokenValidator;

        public CustomJwtSecurityTokenHandler(ISecurityTokenValidator tokenValidator)
        {
            _tokenValidator = tokenValidator;
        }

        public override ClaimsPrincipal ValidateToken(string token, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            return _tokenValidator.ValidateToken(token, validationParameters, out validatedToken);
        }
    }
}
