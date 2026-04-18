namespace BrewChain.Models;

public class ShopStock
{
    public Guid Id { get; set; }
    public Guid ShopId { get; set; }
    public Shop Shop { get; set; } = null!; // Navigation property to represent the relationship with Shop as Many-to-One

    public Guid BeerId { get; set; }
    public Beer Beer { get; set; } = null!; // Navigation property to represent the relationship with Beer as Many-to-One

    public required int Quantity { get; set; }
}
