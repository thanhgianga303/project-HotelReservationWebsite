using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;
using Microsoft.AspNetCore.Http;

namespace HotelReservationWebsite.ViewModels
{
    public class HotelViewModel
    {
        public string SearchString { get; set; }
        public string Genre { get; set; }
        public int pageIndex { get; set; }
        public IFormFile ImageUrl { get; set; }
        public List<City> Cities { get; set; }
        public Hotel Hotel { get; set; }
        public IList<Hotel> Hotels { get; set; }
    }
}