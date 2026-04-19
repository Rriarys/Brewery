namespace BrewChain.Models;

public class Wholesaler
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; } // e.g., "US", "DE"

    public Guid WalletId { get; set; }
    public Wallet Wallet { get; set; } = null!;

    public List<WholesalerStock> Stocks { get; set; } = new(); // Navigation property to represent the relationship with WholesalerStock as One-to-Many
}
