using BrewChain.Data;
using BrewChain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly BrewChainDbContext _dbContext;

        public BeersController(BrewChainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/beers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeerDto>>> GetBeers()
        {
            var beers = await _dbContext.Beers
                .Select(b => new BeerDto(
                    b.Id, 
                    b.Name, 
                    b.AlcoholContent, 
                    b.Price, 
                    b.Brewery.Name))
                .ToListAsync();
            return Ok(beers);
        }

        // GET: api/beers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetBeer(Guid id)
        {
            var beer = await _dbContext.Beers
                .Where(b => b.Id == id)
                .Select(b => new BeerDto(
                    b.Id, 
                    b.Name, 
                    b.AlcoholContent, 
                    b.Price, 
                    b.Brewery.Name))
                .FirstOrDefaultAsync();
            if (beer == null)
            {
                return NotFound(new { Message = $"Beer with ID {id} not found." });
            }
            return Ok(beer);
        }
    }
}