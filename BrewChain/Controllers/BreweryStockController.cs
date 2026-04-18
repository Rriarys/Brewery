using Microsoft.AspNetCore.Mvc;
using BrewChain.Data;
using BrewChain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryStocksController : ControllerBase
    {
        private readonly BrewChainDbContext _dbContext;

        public BreweryStocksController(BrewChainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/brewerystocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreweryStockDto>>> GetBreweryStocks()
        {
            var breweryStocks = await _dbContext.BreweryStocks
                .Select(bs => new BreweryStockDto(
                    bs.Id,
                    bs.Brewery.Name,
                    bs.Beer.Name,
                    bs.Quantity))
                .ToListAsync();
            return Ok(breweryStocks);
        }

        // GET: api/brewerystocks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BreweryStockDto>> GetBreweryStock(Guid id)
        {
            var stock = await _dbContext.BreweryStocks
                .Where(bs => bs.Id == id)
                .Select(bs => new BreweryStockDto(
                    bs.Id,
                    bs.Brewery.Name,
                    bs.Beer.Name,
                    bs.Quantity))
                .FirstOrDefaultAsync();
            if (stock == null)
            {
                return NotFound(new { Message = $"Brewery stock with ID {id} not found." });
            }
            return Ok(stock);
        }
    }
}