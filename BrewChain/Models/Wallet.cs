namespace BrewChain.Models;

public class Wallet
{
    public Guid Id { get; set; }
    public decimal Balance { get; set; }
    public decimal LockedBalance { get; set; } // Escrowed funds
    public decimal AvailableBalance => Balance - LockedBalance; // Funds that can be used for transactions (db dont store this, calculated on the fly)
}
