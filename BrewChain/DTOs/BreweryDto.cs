namespace BrewChain.DTOs;

public record  BreweryDto (
    Guid Id, 
    string Name,
    string Country,
    Guid WalletId
    );
