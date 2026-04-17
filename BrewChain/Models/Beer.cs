namespace BrewChain.Models;

public class Beer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required decimal AlcoholContent { get; set; }
    public required decimal Price { get; set; }

    public Guid BreweryId { get; set; }
    public Brewery Brewery { get; set; } = null!; // Navigation property to represent the relationship with Brewery as Many-to-One
}
