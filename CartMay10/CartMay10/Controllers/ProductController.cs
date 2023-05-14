using CartMay10.Entity;
using CartMay10.Service;
using Microsoft.AspNetCore.Mvc;

namespace CartMay10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(ProductService productService)
        {
            _service=productService;
        }
        [HttpGet]
        public IActionResult GetProduct(string? key, double? froms, double? tos)
        {
            try
            {
                IEnumerable<Product> iep=  _service.GetBySearch(key, froms,tos);

                return iep!=null?Ok(iep):NotFound();

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(string? id) {
            try
            {
                Product product = _service.GetProductById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
