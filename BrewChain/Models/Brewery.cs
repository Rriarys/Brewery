namespace BrewChain.Models;

public class Brewery
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public List<Beer> Beers { get; set; } = new(); // Navigation property to represent the relationship with Beer as One-to-Many
    public List<BreweryStock> BreweryStocks { get; set; } = new(); // Navigation property to represent the relationship with BreweryStock as One-to-Many
}
