using HotelReservationWebsiteAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data
{
    public class HotelReservationWebsiteContext : DbContext
    {
        public HotelReservationWebsiteContext(DbContextOptions<HotelReservationWebsiteContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomCategory> RoomCategories { get; set; }

    }
}