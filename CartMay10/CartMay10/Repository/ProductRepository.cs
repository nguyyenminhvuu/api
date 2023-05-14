using CartMay10.Entity;

namespace CartMay10.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly TestOneContext _context;

        public ProductRepository(TestOneContext context) { 
        _context=context;
        }

        public IEnumerable<Product> GetProduct()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(string? id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<Product> SearchByName(string? key)
        {
            return _context.Products.Where(x => x.Name.Contains(key)).ToList();
        }
  
        public IEnumerable<Product> SearchByPrice(double? froms, double? tos)
        {
           return _context.Products.Where(x=>(x.Price> froms && x.Price<=tos) ).ToList();
        }

        public IEnumerable<Product> SearchLowerPrice(double? tos)
        {
            return _context.Products.Where(x=>x.Price<=tos).ToList();
        }

        public IEnumerable<Product> SearchUpperPrice(double? froms)
        {
           return _context.Products.Where(x=>x.Price>=froms).ToList();
        }
    }
}
