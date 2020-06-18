using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.ViewModels
{
    public class AdminViewModel
    {
        public int NumberOfCustomers { get; set; }
        public int NumberOfHotels { get; set; }
        public int NumberOfBookings { get; set; }
        public decimal totalTransactionAmount { get; set; }
    }
}