using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; } = 0;
        public string? Color { get; set; }
        public decimal Price { get; set; } = 0;
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}