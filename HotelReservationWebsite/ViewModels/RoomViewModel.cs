using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace HotelReservationWebsite.ViewModels
{
    public class RoomViewModel
    {
        public string SearchString { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int pageIndex { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int HotelId { get; set; }
        public string ImageUrlDisPlay { get; set; }
        public Room Room { get; set; }
        public List<RoomCategory> RoomCategories { get; set; }
        public IList<Room> Rooms { get; set; }
    }
}