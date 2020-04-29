using System.Collections.Generic;

namespace CartApi.Models
{
    public class Cart
    {
        public Cart() { }

        public Cart(string buyerId)
        {
            Id = buyerId;
        }

        public string Id { get; set; }
        
        public IEnumerable<CartItem> Items { get; set; } = new List<CartItem>();
    }
}