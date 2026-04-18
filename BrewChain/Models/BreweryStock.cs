namespace BrewChain.Models;

public class BreweryStock
{
    public Guid Id { get; set; }
    public Guid BreweryId { get; set; }
    public Brewery Brewery { get; set; } = null!; // Navigation property to represent the relationship with Brewery as Many-to-One

    public Guid BeerId { get; set; }
    public Beer Beer { get; set; } = null!; // Navigation property to represent the relationship with Beer as Many-to-One

    public required int Quantity { get; set; }
}
