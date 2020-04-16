using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.ViewModels
{
    public class CityViewModel
    {
        public string SearchString { get; set; }
        public IList<City> Cities { get; set; }
    }
}