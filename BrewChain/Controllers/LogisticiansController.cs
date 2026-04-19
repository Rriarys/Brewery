using Microsoft.AspNetCore.Mvc;
using BrewChain.Data;
using BrewChain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticiansController : ControllerBase
    {
        private readonly BrewChainDbContext _dbContext;

        public LogisticiansController(BrewChainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/logisticians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogisticianDto>>> GetLogisticians()
        {
            // Fetch all logisticians from the database into list of entities
            var logisticiansEntities = await _dbContext.Logisticians.ToListAsync();

            // Convert list of entities to list of DTOs using the factory method
            var logisticiansDto = logisticiansEntities
                .Select(LogisticianDto.FromEntity)
                .ToList();

            return Ok(logisticiansDto);
        }

        // GET: api/logisticians/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LogisticianDto>> GetLogistician(Guid id)
        {
            // Fetch the logistician entity by ID
            var logisticianEntity = await _dbContext.Logisticians
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync();

            if (logisticianEntity == null)
            {
                return NotFound(new { Message = $"Logistician with ID {id} not found." });
            }

            // Convert the entity to a DTO using the factory method
            var logisticianDto = LogisticianDto.FromEntity(logisticianEntity);

            return Ok(logisticianDto);
        }
    }
}
