using System;
using System.Collections.Generic;

namespace CartMay10.Entity
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? Img { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
