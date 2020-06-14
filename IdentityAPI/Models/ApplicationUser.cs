using System;
using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string IdentityCard { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public String Address { get; set; }
        public String Role { get; set; }
    }
    public enum Gender
    {
        Male = 0,
        Female = 1,
    }
}