using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HotelReservationWebsiteAPI.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Hotel> Hotels { get; set; }
        public virtual List<Room> Rooms { get; set; }

    }
}
