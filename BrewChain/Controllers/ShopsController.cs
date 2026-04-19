using Microsoft.AspNetCore.Mvc;
using BrewChain.Data;
using BrewChain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly BrewChainDbContext _dbContext;

        public ShopsController(BrewChainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopDto>>> GetShops()
        {
            var shops = await _dbContext.Shops
                .Select(s => new ShopDto(
                    s.Id, 
                    s.Name,
                    s.Country,
                    s.WalletId))
                .ToListAsync();
            return Ok(shops);
        }

        // GET: api/shops/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopDto>> GetShop(Guid id)
        {
            var shop = await _dbContext.Shops
                .Where(s => s.Id == id)
                .Select(s => new ShopDto(
                    s.Id, 
                    s.Name,
                    s.Country,
                    s.WalletId))
                .FirstOrDefaultAsync();
            if (shop == null)
            {
                return NotFound(new { Message = $"Shop with ID {id} not found." });
            }
            return Ok(shop);
        }
    }
}
