using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationWebsiteAPI.Models.InputModel
{
    public class InputChangeInfoModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}