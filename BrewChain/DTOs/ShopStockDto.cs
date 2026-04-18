namespace BrewChain.DTOs;

public record ShopStockDto (
    Guid Id,
    string ShopName,
    string BeerName,
    int Quantity
);
