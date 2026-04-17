namespace BrewChain.Models;

public class Wholesaler
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public List<WholesalerStock> Stocks { get; set; } = new(); // Navigation property to represent the relationship with WholesalerStock as One-to-Many
}
