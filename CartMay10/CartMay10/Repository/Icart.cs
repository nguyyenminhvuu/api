using CartMay10.Entity;
using CartMay10.ModelView;

namespace CartMay10.Repository
{
    public interface Icart
    {
        public IEnumerable<CartView> GetCartDetail();
        public CartView UpdateCartDetail(CartItem item);
        public CartView AddToCart(CartItem item);
        public void CreateCart(Cart cart);
        public IEnumerable<CartItem> GetCartItemByIdCart(int id);
        public Cart GetCartByIdUser(int id);
        public void AmountCart(int idCart, double amounts);
        public void RemoveCart(CartItem item);
    }
}
