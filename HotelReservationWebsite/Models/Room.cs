using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationWebsite.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public string RoomCategoryName { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]{1}[0-9]{0,1}$", ErrorMessage = "Please enter the number")]
        public int RoomNumber { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 60")]
        [RegularExpression(@"^[A-Z]+[a-z""'\s-]+[0-9]*$", ErrorMessage = "Please enter the format: the first letter must be uppercase")]
        public string RoomName { get; set; }
        public int RoomStatus { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]{1}[0-9]{0,}$", ErrorMessage = "Please enter the number: The first numeric character must be greater than 0")]
        public decimal UnitPrice { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 60")]
        [RegularExpression(@"^[1-9]+[0-9]*\s+[a-zA-Z]*\s+[a-zA-Z]*$", ErrorMessage = "Please enter the format")]
        public string RoomArea { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Length must be between 1 to 3")]
        [RegularExpression(@"^[1-9]+[0-9]*$", ErrorMessage = "Please enter the number")]
        public string NumberOfBeds { get; set; }
        public string OwnerId { get; set; }
        public Hotel Hotel { get; set; }
        public RoomCategory RoomCategory { get; set; }
    }

}