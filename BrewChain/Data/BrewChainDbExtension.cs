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
        using var scope = host.Services.CreateScope(); // Create a temporary scope to resolve scoped services (DbContext, Logger) since there is no active HTTP request during application startup.
        var dbContext = scope.ServiceProvider.GetRequiredService<BrewChainDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<BrewChainDbContext>>();

        try // If i forgot to add a property or made a mistake in the seeding logic, this will catch the exception and log it instead of crashing the application
        {   
             // Call the seeding method to populate the database with initial data if necessary. The seeding method should check if the data already exists to avoid duplicate entries on every startup.
            BrewChainDbSeeder.Seed(dbContext); // Method already contains SaveChanges()
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
}
