using BrewChain.Data;
using BrewChain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly BrewChainDbContext _dbContext;

        public BreweriesController(BrewChainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/breweries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreweryDto>>> GetBreweries()
        {
            var breweries = await _dbContext.Breweries
            .Select(b => new BreweryDto(b.Id, b.Name))
            .ToListAsync();
            return Ok(breweries);
        }

        // GET: api/breweries/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BreweryDto>> GetBrewery(Guid id)
        {
            var brewery = await _dbContext.Breweries
            .Where(b => b.Id == id)
            .Select(b => new BreweryDto(b.Id, b.Name))
            .FirstOrDefaultAsync();
            if (brewery == null)
            {
                return NotFound(new { Message = $"Brewery with ID {id} not found." });
            }
            return Ok(brewery);
        }
    }
}
