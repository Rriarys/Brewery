namespace BrewChain.DTOs;

public record WholesalerStockDto (
    Guid Id,
    string WholesalerId,
    string BeerName,
    int Quantity
    );
