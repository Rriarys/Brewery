using BrewChain.Models;

namespace BrewChain.DTOs;

public record LogisticianDto(
    Guid Id, 
    string Name, 
    List<string> TransportServices, // List of enabled services from enum
    Guid WalletId)
{
    // Factory method to convert from Logistician entity to DTO (placed here for convenience)
    public static LogisticianDto FromEntity(Logistician l) => new(
        l.Id,
        l.Name,
        l.SupportedTransports
            .ToString()             // Get "RoadOnly, AirFreight or SeaFreight"
            .Split(',')             // Split into array
            .Select(s => s.Trim())  // Clean up spaces
            .ToList(),              // Convert to List<string>
        l.WalletId
    );
}