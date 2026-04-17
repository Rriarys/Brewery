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
}
