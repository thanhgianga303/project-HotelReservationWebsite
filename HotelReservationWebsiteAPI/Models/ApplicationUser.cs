using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HotelReservationWebsiteAPI.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual Customer Customers { get; set; }
    }
}
