namespace CartApi.Models
{
    public class CartItem
    {
        public string Id { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int AddressId { get; set; }
        public string HotelAddress { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public decimal UnitPrice { get; set; }
        public int numberOfRooms {get; set;}
        public int numberOfStandardRooms{get;set;}
        public int numberOfSuperiorRooms{get;set;}
        public int numberOfDeluxeRooms{get;set;}
        public int numberOfSuiteRooms{get;set;}
    }
}