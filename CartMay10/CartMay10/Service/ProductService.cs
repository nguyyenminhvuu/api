using CartMay10.Entity;
using CartMay10.Repository;

namespace CartMay10.Service
{
    public class ProductService
    {
        private readonly IProduct _iProduct;

        public ProductService(IProduct ip) {
            _iProduct = ip;
        }
        public IEnumerable<Product> GetBySearch(string? key, double? froms, double? tos)
        {
            IEnumerable<Product> products;
            products = (!string.IsNullOrEmpty(key) ? _iProduct.SearchByName(key) : _iProduct.GetProduct());
            if (froms != null)
            {
                products = products.Where(x => x.Price >= froms);
            }
            if (tos != null)
            {
                products = products.Where(x => x.Price <= tos);
            }
                return products;
        }
        public Product GetProductById(string? id)
        {
            try
            {
                return _iProduct.GetProductById(id);    
            }
            catch
            {
                return null;
            }
        }
        
    }
}
