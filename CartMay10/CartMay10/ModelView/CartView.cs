namespace CartMay10.ModelView
{
    public class CartView
    {
        public int IdCart { get; set; }
        public string IdProduct { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
