namespace BrewChain.DTOs;

public record WalletDto (
    Guid Id,
    decimal Balance,
    decimal LockedBalance,
    decimal AvailableBalance
    );
