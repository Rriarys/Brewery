using Microsoft.AspNetCore.Mvc;
using BrewChain.Data;
using BrewChain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesalerStocksController : ControllerBase
    {
        private readonly BrewChainDbContext _dbContext;

        public WholesalerStocksController(BrewChainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/wholesalerstocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WholesalerStockDto>>> GetWholesalerStocks()
        {
            var stocks = await _dbContext.WholesalerStocks
                .Select(ws => new WholesalerStockDto(
                    ws.Id, 
                    ws.Wholesaler.Name, 
                    ws.Beer.Name, 
                    ws.Quantity))
                .ToListAsync();
            return Ok(stocks);
        }

        // GET: api/wholesalerstocks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WholesalerStockDto>> GetWholesalerStock(Guid id)
        {
            var stock = await _dbContext.WholesalerStocks
                .Where(ws => ws.Id == id)
                .Select(ws => new WholesalerStockDto(
                    ws.Id, 
                    ws.Wholesaler.Name, 
                    ws.Beer.Name, 
                    ws.Quantity))
                .FirstOrDefaultAsync();
            if (stock == null)
            {
                return NotFound(new { Message = $"Wholesaler stock with ID {id} not found." });
            }
            return Ok(stock);
        }
    }
}
