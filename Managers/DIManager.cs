using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Qimmah.Application.System;
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

        public static void InjectIdentity(this IServiceCollection Services, IConfiguration configuration)
        {

            Services.AddSingleton<ISecurityTokenValidator, JwtTokenValidator>();
            Services.AddSingleton<JwtSecurityTokenHandler, CustomJwtSecurityTokenHandler>();
            Services.AddIdentity<Users, IdentityRole<long>>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

                // Password settings. 
                //options.Password.RequireDigit = true;
                //options.Password.RequireLowercase = true;
                //options.Password.RequireNonAlphanumeric = true;
                //options.Password.RequireUppercase = true;
                //options.Password.RequiredLength = 6;
                //options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.SaveToken = true;

               // Inject the custom handler into the options
               options.TokenHandlers.Add(Services.BuildServiceProvider().GetRequiredService<JwtSecurityTokenHandler>());

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = configuration["Jwt:Issuer"],
                   ValidAudience = configuration["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
               };

               options.Events = new JwtBearerEvents
               {
                   OnTokenValidated = context =>
                   {
                       Console.WriteLine("Token validated successfully.");
                       return Task.CompletedTask;
                   },
                   OnAuthenticationFailed = context =>
                   {
                       Console.WriteLine("Token validation failed: " + context.Exception.Message);
                       return Task.CompletedTask;
                   }
               };
           });

            Services.AddAuthorization();

        }

        public static void InjectServices(this IServiceCollection Services)
        {
            Services.AddScoped<ILookupService, LookupService>();
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
