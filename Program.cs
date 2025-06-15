using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Qimmah.Application;
using Qimmah.Attributes.FilterAttributes;
using Qimmah.Core;
using Qimmah.Data;
using Qimmah.Managers;
using Qimmah.Managers.SeedManagers;

namespace Qimmah
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
           
            //DB
            builder.Services.InjectDB(connectionString);
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //IDentity
            builder.Services.InjectIdentity(builder.Configuration);
            //Services
            builder.Services.InjectServices();

            builder.Services.AddControllersWithViews();
            //Options
            builder.Services.AddOptions();

            builder.Services.AddRazorPages();
            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton(typeof(IDictionaryCacheService<,>), typeof(DictionaryCacheService<,>));
            // ✳️ Configure logging
            builder.Logging.ClearProviders(); // optional: remove default ones
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
            builder.Logging.AddEventLog(); // for Windows event log (optional)

            builder.Logging.SetMinimumLevel(LogLevel.Debug); // Or Information, Trace, etc.

            builder.Services.AddScoped<ActiveTabFilter>();

            //Filters
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<ActiveTabFilter>(); // Add the filter globally
            });




            var app = builder.Build();
            var cacheManager = new CacheManagers(app.Services, app.Services.GetRequiredService<IMemoryCache>());
            cacheManager.StartLocalizationCacheRefresh();
            await cacheManager.CacheLanguages();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                using (var scope = app.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    db.Database.Migrate();
                }
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();                          
            }

            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseAuthentication(); 
            app.UseAuthorization();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedProto
            });
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Call your extension methods or seeding logic here
                await services.SeedRolesAsync();
                await services.SeedAdminUserAsync(); // if you have this
            }
            app.Run();
        }
    }
}
