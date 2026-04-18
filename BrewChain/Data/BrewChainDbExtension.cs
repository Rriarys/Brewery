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

        // Create some stock entries for the breweries
        var breweryStock1 = new BreweryStock{
            Brewery = abbate,
            Beer = leffeBlonde,
            Quantity = 200
        };
        var breweryStock2 = new BreweryStock{
            Brewery = abbate,
            Beer = leffeBrune,
            Quantity = 150
        };
        var breweryStock3 = new BreweryStock{
            Brewery = chimay,
            Beer = chimayRed,
            Quantity = 120
        };
        var breweryStock4 = new BreweryStock{
            Brewery = chimay,
            Beer = chimayBlue,
            Quantity = 100
        };
        var breweryStock5 = new BreweryStock{
            Brewery = chimay,
            Beer = chimayTriple,
            Quantity = 90
        };

        // Create some shops
        var shop1 = new Shop { Name = "Downtown Beer Store" };
        var shop2 = new Shop { Name = "Craft Beer Emporium" };
        var shop3 = new Shop { Name = "The Beer Cellar" };
        var shop4 = new Shop { Name = "Hoppy Haven" };
        var shop5 = new Shop { Name = "Brew & Co." };

        // Create some stock entries for the shops
        var shopStock1 = new ShopStock{
            Shop = shop1,
            Beer = leffeBlonde,
            Quantity = 20
        };
        var shopStock2 = new ShopStock{
            Shop = shop1,
            Beer = chimayRed,
            Quantity = 15
        };
        var shopStock3 = new ShopStock{
            Shop = shop2,
            Beer = chimayBlue,
            Quantity = 10
        };
        var shopStock4 = new ShopStock{     
            Shop = shop3,
            Beer = chimayTriple,
            Quantity = 5
        };
        var shopStock5 = new ShopStock{
            Shop = shop4,
            Beer = leffeBrune,
            Quantity = 25
        };

        // Add the entities to the context and save changes
        dbContext.Breweries.AddRange(abbate, chimay);
        dbContext.Beers.AddRange(leffeBlonde, leffeBrune, chimayRed, chimayBlue, chimayTriple);
        dbContext.BreweryStocks.AddRange(breweryStock1, breweryStock2, breweryStock3, breweryStock4, breweryStock5);
        dbContext.Wholesalers.AddRange(wholesaler1, wholesaler2);
        dbContext.WholesalerStocks.AddRange(stock1, stock2, stock3, stock4, stock5);
        dbContext.Shops.AddRange(shop1, shop2, shop3, shop4, shop5);
        dbContext.ShopStocks.AddRange(shopStock1, shopStock2, shopStock3, shopStock4, shopStock5);

        try // If i forgot to add a property or made a mistake in the seeding logic, this will catch the exception and log it instead of crashing the application
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
