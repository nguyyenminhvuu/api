using System;
using System.Collections.Generic;

namespace CartMay10.Entity
{
    public partial class CartItem
    {
        public int IdCart { get; set; }
        public string IdProduct { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public virtual Cart IdCartNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
