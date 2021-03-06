using HotelReservationWebsiteAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data
{
    public class HotelReservationWebsiteContext : DbContext
    // : IdentityDbContext<ApplicationUser>
    {
        public HotelReservationWebsiteContext(DbContextOptions<HotelReservationWebsiteContext> options) : base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        // base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        // }

    }
}