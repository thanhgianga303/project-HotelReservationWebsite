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
        public decimal UnitPrice { get; set; }
        public int RoomStatus { get; set; }

        public virtual List<BookingDetail> BookingDetails { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Promotion Promotion { get; set; }
        public virtual RoomCategory RoomCategory { get; set; }
    }

}