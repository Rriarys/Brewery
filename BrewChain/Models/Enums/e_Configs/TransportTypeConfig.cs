namespace BrewChain.Models.Enums.e_Configs;

public class TransportTypeConfig
{
    // Dictionary to store (Speed, CostMultiplier, BaseRiskScore)
    // Speed: higher is faster
    // Cost: higher is more expensive
    // Risk: higher is more dangerous (0.0 to 1.0)
    public static readonly Dictionary<TransportType, (int Speed, decimal CostMult, double BaseRisk)> Stats = new()
    {
        { TransportType.RoadOnly,   (Speed: 5,  CostMult: 1.0m, BaseRisk: 0.05) },
        { TransportType.AirFreight, (Speed: 10, CostMult: 2.5m, BaseRisk: 0.12) },
        { TransportType.SeaFreight, (Speed: 2,  CostMult: 0.5m, BaseRisk: 0.02) }
    };
}
