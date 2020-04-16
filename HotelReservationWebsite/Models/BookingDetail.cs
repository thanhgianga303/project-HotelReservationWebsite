using System;
namespace HotelReservationWebsite.Models
{
    public class BookingDetail
    {
        public int BookingDetailID { get; set; }
        public int RoomID { get; set; }
        public int CustomerID { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int BookingDetailStatus { get; set; }
    }

}