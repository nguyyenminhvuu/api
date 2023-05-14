using CartMay10.Entity;
using CartMay10.ModelView;
using CartMay10.Repository;

namespace CartMay10.Service
{
    public class CartService
    {
        private readonly Icart _iCart;
        private readonly IProduct _iProduct;

        public CartService(Icart icart,IProduct ip) {
            _iCart = icart;
            _iProduct=ip;
        }
        public CartView UpdateCart(int user, string idProduct, int quantity)
        {
            Product p = _iProduct.GetProductById(idProduct);
            Cart cart =GetCarByIdUser(user);
            if (cart == null)
            {
                cart = new Cart { 
                IdUser = user,
                Amount = quantity * p.Price,
                };
                _iCart.CreateCart(cart);    
            }
            IEnumerable<CartItem> cartItems = GetCartItemByIdCart(cart.Id);
            CartItem cartItem = new CartItem
            {
                IdCart = cart.Id,
                IdProduct = idProduct,
                Quantity = quantity,
                Price = p.Price
            };
            Boolean check = true;
            double total = 0;
            foreach (CartItem item in cartItems)
            {
               
                if (item.IdProduct.Equals(idProduct))
                {
                    cartItem.Quantity += item.Quantity;
                    check = false;
                }
                else
                {
                    total += item.Price*item.Quantity;
                }    
            }
            if (!check)
            {
                if (cartItem.Quantity<=0)
                {
                    _iCart.AmountCart(cartItem.IdCart, total);
                    _iCart.RemoveCart(cartItem);
                    return null;
                }
                else
                {
                    total += cartItem.Price * cartItem.Quantity;
                    _iCart.AmountCart(cartItem.IdCart, total);
                    return _iCart.UpdateCartDetail(cartItem);
                }
            }
            else
            {
                total += cartItem.Price * cartItem.Quantity;
                _iCart.AmountCart(cartItem.IdCart, total);
                return _iCart.AddToCart(cartItem);
            }
        }
        public IEnumerable<CartItem> GetCartItemByIdCart(int id)
        {
            return _iCart.GetCartItemByIdCart(id).ToList();
        }
        public Cart GetCarByIdUser(int id)
        {
            return _iCart.GetCartByIdUser(id);
        }
    }
}
