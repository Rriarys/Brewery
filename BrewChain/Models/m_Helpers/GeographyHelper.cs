namespace BrewChain.Models.m_Helpers;

public class GeographyHelper
{
    // ISO 3166-1 alpha-2 codes of EU countries with major maritime ports
    private static readonly HashSet<string> EuCountriesWithPorts = new(StringComparer.OrdinalIgnoreCase)
    {
        "BE", // Belgium
        "BG", // Bulgaria
        "CY", // Cyprus
        "DK", // Denmark
        "EE", // Estonia
        "FI", // Finland
        "FR", // France
        "DE", // Germany
        "GR", // Greece
        "IE", // Ireland
        "IT", // Italy
        "LV", // Latvia
        "LT", // Lithuania
        "MT", // Malta
        "NL", // Netherlands
        "PL", // Poland
        "PT", // Portugal
        "RO", // Romania
        "ES", // Spain
        "SE"  // Sweden
    };

    // Method to check if a delivery by ship is possible to/from a specific country (yes - true, no - false)
    public static bool HasMaritimePort(string countryCode)
    {
        return EuCountriesWithPorts.Contains(countryCode.Trim());
    }
}
