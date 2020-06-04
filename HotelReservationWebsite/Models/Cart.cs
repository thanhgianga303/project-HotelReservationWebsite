using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservationWebsite.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice), 2);
        }
    }
}