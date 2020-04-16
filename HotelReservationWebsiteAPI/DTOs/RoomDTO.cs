using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.DTOs
{
    public class RoomDTO
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public int PromotionID { get; set; }
        public int RoomCategoryID { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public int RoomStatus { get; set; }
    }

}