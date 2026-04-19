namespace BrewChain.DTOs;

public record WholesalerDto (
    Guid Id,
    string Name,
    string Country,
    Guid WalletId
    );
