using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationWebsite.Models
{
    public class RoomCategory
    {
        public int RoomCategoryID { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 60")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please enter the format: the first letter must be uppercase, the letter has no number")]
        public string CategoryName { get; set; }
    }

}