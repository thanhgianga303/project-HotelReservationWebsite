using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.ViewModels
{
    public class UserViewModel
    {
        public string SearchString { get; set; }
        public User User { get; set; }
        public IList<User> Users { get; set; }
    }
}