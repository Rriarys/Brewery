using Microsoft.AspNetCore.Mvc;
using BrewChain.Data;
using BrewChain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesalersController : ControllerBase
    {
        private readonly BrewChainDbContext _dbContext;

        public WholesalersController(BrewChainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/wholesalers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WholesalerDto>>> GetWholesalers()
        {
            var wholesalers = await _dbContext.Wholesalers
                .Select(w => new WholesalerDto(w.Id, w.Name))
                .ToListAsync();
            return Ok(wholesalers);
        }

        // GET: api/wholesalers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WholesalerDto>> GetWholesaler(Guid id)
        {
            var wholesaler = await _dbContext.Wholesalers
                .Where(w => w.Id == id)
                .Select(w => new WholesalerDto(w.Id, w.Name))
                .FirstOrDefaultAsync();
            if (wholesaler == null)
            {
                return NotFound(new { Message = $"Wholesaler with ID {id} not found." });
            }
            return Ok(wholesaler);
        }
    }
}

