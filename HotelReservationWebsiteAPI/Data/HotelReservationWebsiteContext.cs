using HotelReservationWebsiteAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data
{
    public class HotelReservationWebsiteContext : DbContext
    {
        public HotelReservationWebsiteContext(DbContextOptions<HotelReservationWebsiteContext> options) : base(options)
        {

        }
        public DbSet<Account> Account { get; set; }
    }
}