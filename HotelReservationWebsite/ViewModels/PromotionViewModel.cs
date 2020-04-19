using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.ViewModels
{
    public class PromotionViewModel
    {
        public string SearchString { get; set; }
        public string Genre { get; set; }
        public int pageIndex { get; set; }
        public Promotion Promotion { get; set; }
        public IList<Promotion> Promotions { get; set; }
    }
}