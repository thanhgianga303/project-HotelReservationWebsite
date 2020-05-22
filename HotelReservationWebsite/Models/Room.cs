using System.Collections.Generic;
namespace HotelReservationWebsite.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public int PromotionID { get; set; }
        public int RoomCategoryID { get; set; }
        public string ImageUrl { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public int RoomStatus { get; set; }
    }

}