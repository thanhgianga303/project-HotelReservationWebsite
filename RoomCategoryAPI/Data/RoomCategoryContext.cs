using RoomCategoryAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace RoomCategoryAPI.Data
{
    public class RoomCategoryContext : DbContext
    // : IdentityDbContext<ApplicationUser>
    {
        public RoomCategoryContext(DbContextOptions<RoomCategoryContext> options) : base(options)
        {

        }
        public DbSet<RoomCategory> RoomCategories { get; set; }
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        // base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        // }

    }
}