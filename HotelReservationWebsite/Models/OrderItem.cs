namespace HotelReservationWebsite.Models
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string PictureUri { get; set; }
        public int Units { get; set; }
    }
}