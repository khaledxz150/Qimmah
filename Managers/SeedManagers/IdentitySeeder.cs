using Microsoft.AspNetCore.Identity;
using Qimmah.Data.User;
namespace Qimmah.Managers.SeedManagers;
public static class ApplicationDbContextSeedExtensions
{
    public static async Task SeedRolesAsync(this IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<long>>>();

        string[] roles = { "Admin", "User" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole<long>(role));
        }
    }

    public static async Task SeedAdminUserAsync(this IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<Users>>();
        var adminEmail = "admin@example.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var user = new Users
            {
                UserName = adminEmail,
                Email = adminEmail,
                LanguageID = 1
            };

            var result = await userManager.CreateAsync(user, "Admin@123");

            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
