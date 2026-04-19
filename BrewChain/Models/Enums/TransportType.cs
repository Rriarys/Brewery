namespace BrewChain.Models.Enums.e_Configs;

[Flags]
public enum TransportType
{
    None = 0,
    // Standard trucking (Road only). Medium cost, medium speed
    RoadOnly = 1, 
    // Truck -> Plane -> Truck. High cost, high speed
    AirFreight = 2, 
    // Truck -> Ship -> Truck. Low cost, low speed. Requires Ports
    SeaFreight = 4  
}