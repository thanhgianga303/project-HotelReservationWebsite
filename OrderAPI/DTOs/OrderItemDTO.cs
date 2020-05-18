namespace OrderAPI.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string PictureUri { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int AddressId { get; set; }
        public string AddressName { get; set; }
        public decimal UnitPrice { get; set; }
        // public virtual Order Order { get; set; }
    }
}