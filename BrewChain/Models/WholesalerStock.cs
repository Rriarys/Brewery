namespace BrewChain.Models;

public class WholesalerStock
{
    public Guid Id { get; set; }
    public Guid WholesalerId { get; set; }
    public Wholesaler Wholesaler { get; set; } = null!; // Navigation property to represent the relationship with Wholesaler as Many-to-One

    public Guid BeerId { get; set; }
    public Beer Beer { get; set; } = null!; // Navigation property to represent the relationship with Beer as Many-to-One

    public required int Quantity { get; set; }
}

