using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace HotelReservationWebsite.ViewModels
{
    public class HotelViewModel
    {
        public string SearchString { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int hotelID { get; set; }
        public string ImageUrlDisplay { get; set; }
        public IFormFile ImageUrl { get; set; }
        public List<City> Cities { get; set; }
        public Hotel Hotel { get; set; }
        public IList<Hotel> Hotels { get; set; }
    }
}