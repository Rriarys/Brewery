namespace BrewChain.Models;

public class Brewery
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; } // e.g., "US", "DE"

    public Guid WalletId { get; set; }
    public Wallet Wallet { get; set; } = null!;

    public List<Beer> Beers { get; set; } = new(); // Navigation property to represent the relationship with Beer as One-to-Many
    public List<BreweryStock> BreweryStocks { get; set; } = new(); // Navigation property to represent the relationship with BreweryStock as One-to-Many
}
