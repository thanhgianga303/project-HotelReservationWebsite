using System.Collections.Generic;
using HotelReservationWebsiteAPI.Models;

namespace HotelReservationWebsiteAPI.DTOs
{
    public class RoomDTO
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public int RoomCategoryID { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public string ImageUrl { get; set; }
        public int RoomStatus { get; set; }
        public decimal UnitPrice { get; set; }
        public string RoomArea { get; set; }
        public string NumberOfBeds { get; set; }

        public Hotel Hotel { get; set; }
        public RoomCategory RoomCategory { get; set; }
    }

}