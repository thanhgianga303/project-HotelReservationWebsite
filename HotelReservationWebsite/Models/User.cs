using System;
using Microsoft.AspNetCore.Identity;

namespace HotelReservationWebsite.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string IdentityCard { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public String Address { get; set; }

    }
    public enum Gender
    {
        Male = 0,
        Female = 1,
    }
}