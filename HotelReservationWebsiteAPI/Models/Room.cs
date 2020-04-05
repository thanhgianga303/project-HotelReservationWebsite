using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public int PromotionID { get; set; }
        public int RoomCategoryID { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public int RoomStatus { get; set; }
        public List<BookingDetail> BookingDetails { get; set; }
        public Hotel Hotel { get; set; }
        public Promotion Promotion { get; set; }
        public RoomCategory RoomCategory { get; set; }
    }

}