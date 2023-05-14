using System;
using System.Collections.Generic;

namespace CartMay10.Entity
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public double? Amount { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
