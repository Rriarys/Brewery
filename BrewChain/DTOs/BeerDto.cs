namespace BrewChain.DTOs;

public record BeerDto (
    Guid Id,
    string Name,
    decimal AlcoholContent,
    decimal Price,
    string BreweryName
    );

