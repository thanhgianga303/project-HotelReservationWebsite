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
        public List<BookingDetail> BookingDetails { get; set; }
        public Hotel Hotel { get; set; }
        public RoomCategory RoomCategory { get; set; }
    }

}