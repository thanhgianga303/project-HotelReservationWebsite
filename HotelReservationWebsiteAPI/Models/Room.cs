using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public string RoomCategoryName { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public string ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public int RoomStatus { get; set; }
        public string OwnerId { get; set; }
        public string RoomArea { get; set; }
        public string NumberOfBeds { get; set; }
        public virtual Hotel Hotel { get; set; }
    }

}