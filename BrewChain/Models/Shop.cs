namespace BrewChain.Models;

public class Shop
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; } // e.g., "US", "DE"

    public Guid WalletId { get; set; }
    public Wallet Wallet { get; set; } = null!;

    public List<ShopStock> ShopStocks { get; set; } = new List<ShopStock>(); // Navigation property to represent the relationship with ShopStock as One-to-Many
}
