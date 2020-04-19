using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.ViewModels
{
    public class RoomViewModel
    {
        public string SearchString { get; set; }
        public string Genre { get; set; }
        public int pageIndex { get; set; }
        public Room Room { get; set; }
        public IList<Room> Rooms { get; set; }
    }
}