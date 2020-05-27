using System;
namespace HotelReservationWebsiteAPI.Models
{
    public class BookingDetail
    {
        public int BookingDetailID { get; set; }
        public int ApplicationUserId { get; set; }
        public int RoomID { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int BookingDetailStatus { get; set; }
        public virtual Room Room { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

}