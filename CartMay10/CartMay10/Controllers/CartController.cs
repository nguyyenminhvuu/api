using CartMay10.Repository;
using CartMay10.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartMay10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _context;

        public CartController(CartService sv) {
        _context= sv; 
        } 
        [HttpGet("{id}")]
        public IActionResult GetCartByIdUser(int id)
        {
            try
            {
                return Ok(_context.GetCarByIdUser(id));
            }catch (Exception ex)   
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("getCartItem/{id}")]
        public IActionResult GetCartItemByIdCart(int idCart) {
            try
            {
                return Ok(_context.GetCartItemByIdCart(idCart));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost()]
        public IActionResult AddToCart(int idUser, string idProduct, int quantity) {
            try
            {
             
                return Ok(_context.UpdateCart(idUser, idProduct, quantity));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
