using BrewChain.Models.Enums.e_Configs;

namespace BrewChain.Models;

public class Logistician
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public Guid WalletId { get; set; }
    public Wallet Wallet { get; set; } = null!; // Navigation property to the wallet

    public TransportType SupportedTransports { get; set; } // Bitwise flag for all transports this company provides
}
