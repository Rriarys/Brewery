namespace BrewChain.DTOs;

public record BreweryStockDto (
    Guid Id,
    string BreweryName,
    string BeerName,
    int Quantity
);
