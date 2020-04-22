using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationWebsiteAPI.Models.InputModel
{
    public class InputUserModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string IdentityCard { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}