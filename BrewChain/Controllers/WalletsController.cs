using Microsoft.AspNetCore.Mvc;
using BrewChain.Data;
using BrewChain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly BrewChainDbContext _dbContext;

        public WalletsController(BrewChainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/wallets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WalletDto>>> GetWallets()
        {
            var wallets = await _dbContext.Wallets
                .Select(w => new WalletDto(
                    w.Id, 
                    w.Balance,
                    w.LockedBalance,
                    w.AvailableBalance))
                .ToListAsync();
            return Ok(wallets);
        }

        // GET: api/wallets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WalletDto>> GetWallet(Guid id)
        {
            var wallet = await _dbContext.Wallets
                .Where(w => w.Id == id)
                .Select(w => new WalletDto(
                    w.Id, 
                    w.Balance,
                    w.LockedBalance,
                    w.AvailableBalance))
                .FirstOrDefaultAsync();
            if (wallet == null)
            {
                return NotFound(new { Message = $"Wallet with ID {id} not found." });
            }
            return Ok(wallet);
        }
    }
}
