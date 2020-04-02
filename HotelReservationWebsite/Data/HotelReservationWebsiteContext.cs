using HotelReservationWebsite.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsite.Data
{
    public class HotelReservationWebsiteContext : DbContext
    {
        public HotelReservationWebsiteContext(DbContextOptions<HotelReservationWebsiteContext> options) : base(options)
        {

        }
        public DbSet<Account> Account { get; set; }
        // public DbSet<Address> AddressList { get; set; }
        // public DbSet<BookingDetail> BookingDetailList { get; set; }
        // public DbSet<City> CityList { get; set; }
        // public DbSet<Customer> CustomerList { get; set; }
        // public DbSet<Employee> EmployeeList { get; set; }
        // public DbSet<Hotel> HotelList { get; set; }
        // public DbSet<Promotion> PromotionList { get; set; }
        // public DbSet<Role> RoleList { get; set; }
        // public DbSet<Room> RoomList { get; set; }
        // public DbSet<RoomCategory> RoomCategoryList { get; set; }
    }
}