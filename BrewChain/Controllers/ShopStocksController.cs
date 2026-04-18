using Microsoft.AspNetCore.Mvc;
using BrewChain.Data;
using BrewChain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopStocksController : ControllerBase
    {
        private readonly BrewChainDbContext _dbContext;

        public ShopStocksController(BrewChainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/shopstocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopStockDto>>> GetShopStocks()
        {
            var shopStocks = await _dbContext.ShopStocks
                .Select(ss => new ShopStockDto(
                    ss.Id, 
                    ss.Shop.Name, 
                    ss.Beer.Name, 
                    ss.Quantity))
                .ToListAsync();
            return Ok(shopStocks);
        }

        // GET: api/shopstocks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopStockDto>> GetShopStock(Guid id)
        {
            var shopStock = await _dbContext.ShopStocks
                .Where(ss => ss.Id == id)
                .Select(ss => new ShopStockDto(
                    ss.Id, 
                    ss.Shop.Name, 
                    ss.Beer.Name, 
                    ss.Quantity))
                .FirstOrDefaultAsync();
            if (shopStock == null)
            {
                return NotFound(new { Message = $"Shop stock with ID {id} not found." });
            }
            return Ok(shopStock);
        }
    }
}
