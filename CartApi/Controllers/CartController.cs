using System.Threading.Tasks;
using CartApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepo;

        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        [HttpGet("{id}")]
        public async Task<Cart> Get(string id)
        {
            return await _cartRepo.GetByAsync(id);
        }

        [HttpPut]
        public async Task<Cart> Update(Cart cart)
        {
            return await _cartRepo.UpdateAsync(cart.Id, cart);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _cartRepo.DeleteAsync(id);
        }
    }
}
