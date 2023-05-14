using CartMay10.Entity;

namespace CartMay10.Repository
{
    public interface IProduct
    {
        public IEnumerable<Product> GetProduct();
        public IEnumerable<Product> SearchByName(string? key);
        public IEnumerable<Product> SearchByPrice(double? froms, double? tos);
        public IEnumerable<Product> SearchUpperPrice(double? froms);
        public IEnumerable<Product> SearchLowerPrice(double? tos);
        public Product GetProductById(string? id);
    }
}
