namespace BrewChain.Models.Enums.e_Configs;

public enum OrderStatus
{
    Created,
    Paid,       // Funds are locked in Escrow
    InTransit,  // Chaos engine takes over
    Arrived,    // Waiting for buyer's action
    Disputed,   // Alert triggered
    Completed,  // Funds released, stock updated
    Cancelled
}
