using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Qimmah.Data.User;

namespace Qimmah.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users, IdentityRole<long>, long>
    {
        public override DbSet<Users> Users { set; get; }
        public DbSet<UserLocalization> UserLocalization { set; get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Users");

            builder.ApplyConfiguration(new UserLocalization_Configuration());
            builder.ApplyConfiguration(new User_Configuration());

            base.OnModelCreating(builder);
        }
    }
}
