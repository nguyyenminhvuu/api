using CartMay10.Entity;
using CartMay10.ModelView;

namespace CartMay10.Repository
{
    public class ICartRepository : Icart
    {
        private readonly TestOneContext _context;

        public ICartRepository(TestOneContext testOneContext) {
            _context = testOneContext;
        }

        public CartView AddToCart(CartItem item)
        {
            _context.CartItems.Add(item);
            _context.SaveChanges();
            return new CartView { IdCart = item.IdCart, IdProduct = item.IdProduct, Quantity = item.Quantity, Price = item.Price };
        }
        public void RemoveCart(CartItem item) {
            var entity = _context.CartItems.Find(item.IdCart, item.IdProduct);
            _context.CartItems.Remove(entity);    
            _context.SaveChanges();
        }
        public void AmountCart(int idCart, double amounts)
        {
            _context.Carts.SingleOrDefault(x=>x.Id==idCart).Amount=amounts;
            _context.SaveChanges();
        }

        public void CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);    
            _context.SaveChanges();
        }

        public Cart GetCartByIdUser(int id)
        {
            Cart cart = _context.Carts.SingleOrDefault(x => x.IdUser==id);
            return cart;
        }

        public IEnumerable<CartView> GetCartDetail()
        {
            return _context.CartItems.Select(x => new CartView {IdCart=x.IdCart, IdProduct=x.IdProduct,Quantity=x.Quantity }).ToList();
        }

        public IEnumerable<CartItem> GetCartItemByIdCart(int id)
        {
           return _context.CartItems.Where(x=>x.IdCart==id).ToList();
        }

        public CartView UpdateCartDetail(CartItem item)
        {
            CartItem itemsCart = _context.CartItems.SingleOrDefault(x => (x.IdCart == item.IdCart)&& (x.IdProduct==item.IdProduct));
            itemsCart.Quantity = item.Quantity;
            _context.SaveChanges();
            
            return new CartView { IdCart= itemsCart.IdCart, IdProduct= itemsCart.IdProduct,Quantity= itemsCart.Quantity,Price= itemsCart.Price };
        }
    }
}
