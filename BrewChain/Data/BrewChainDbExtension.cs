using BrewChain.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Data;

public static class BrewChainDbExtension
{
    // Extension method to add BrewChainDbContext to the service collection with the connection string from configuration
    public static void AddBrewChainDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BrewChainDb")
            ?? throw new InvalidOperationException("Connection string 'BrewChainDb' not found.");
        services.AddDbContext<BrewChainDbContext>(options =>
            options.UseSqlite(connectionString));
    }

    // Extension method to apply any pending migrations to the database at application startup
    public static void MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BrewChainDbContext>();
        dbContext.Database.Migrate();
    }

    // Extension method to seed the database with initial data if necessary
    public static void SeedDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BrewChainDbContext>();
        // Add seeding logic here

        if (dbContext.Breweries.Any()) return; // Database has already been seeded

        // Create some breweries
        var abbate = new Brewery { Name = "Abbaye de Leffe" };
        var chimay = new Brewery { Name = "Brasserie de Chimay" };

        // Create some beers for each brewery
        var leffeBlonde = new Beer
        {
            Name = "Leffe Blonde",
            AlcoholContent = 6.6m,
            Price = 2.5m,
            Brewery = abbate
        };
        var leffeBrune = new Beer
        {
            Name = "Leffe Brune",
            AlcoholContent = 6.5m,
            Price = 2.8m,
            Brewery = abbate
        };
        var chimayRed = new Beer
        {
            Name = "Chimay Rouge",
            AlcoholContent = 7.0m,
            Price = 3.0m,
            Brewery = chimay
        };
        var chimayBlue = new Beer
        {
            Name = "Chimay Bleue",
            AlcoholContent = 9.0m,
            Price = 3.5m,
            Brewery = chimay
        };
        var chimayTriple = new Beer
        {
            Name = "Chimay Triple",
            AlcoholContent = 8.0m,
            Price = 3.2m,
            Brewery = chimay
        };

        // Create some wholesalers
        var wholesaler1 = new Wholesaler { Name = "Brewery Supplies Co." };
        var wholesaler2 = new Wholesaler { Name = "Beer Distributors Inc." };

        // Create some stock entries for the wholesalers
        var stock1 = new WholesalerStock{
            Wholesaler = wholesaler1,
            Beer = leffeBlonde,
            Quantity = 100
        };
        var stock2 = new WholesalerStock{
            Wholesaler = wholesaler1,
            Beer = chimayRed,
            Quantity = 50
        };
            var stock5 = new WholesalerStock{
            Wholesaler = wholesaler1,
            Beer = leffeBrune,
            Quantity = 80
        };
        var stock3 = new WholesalerStock{
            Wholesaler = wholesaler2,
            Beer = chimayBlue,
            Quantity = 75
        };
        var stock4 = new WholesalerStock{
            Wholesaler = wholesaler2,
            Beer = chimayTriple,
            Quantity = 60
        };

        // Add the entities to the context and save changes
        dbContext.Breweries.AddRange(abbate, chimay);
        dbContext.Beers.AddRange(leffeBlonde, leffeBrune, chimayRed, chimayBlue, chimayTriple);
        dbContext.Wholesalers.AddRange(wholesaler1, wholesaler2);
        dbContext.WholesalerStocks.AddRange(stock1, stock2, stock3, stock4, stock5);

        try 
        {
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            // Serilog or any other logging framework can be used here to log the exception
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<BrewChainDbContext>>(); // Static method, so we need to resolve the logger from the service provider
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
}
