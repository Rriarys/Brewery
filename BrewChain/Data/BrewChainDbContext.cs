using BrewChain.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Data;

public class BrewChainDbContext : DbContext
{
    public BrewChainDbContext(DbContextOptions<BrewChainDbContext> options) : base(options) { }

    // DbSet properties to represent the tables in the database
    public DbSet<Brewery> Breweries => Set<Brewery>();
    public DbSet<Beer> Beers => Set<Beer>();
    public DbSet<Wholesaler> Wholesalers => Set<Wholesaler>();
    public DbSet<WholesalerStock> WholesalerStocks => Set<WholesalerStock>();

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure primary keys
        modelBuilder.Entity<Brewery>().HasKey(b => b.Id);
        modelBuilder.Entity<Beer>().HasKey(b => b.Id);
        modelBuilder.Entity<Wholesaler>().HasKey(w => w.Id);
        modelBuilder.Entity<WholesalerStock>().HasKey(s => s.Id);

        // Brewery has many Beers
        modelBuilder.Entity<Brewery>()
            .HasMany(b => b.Beers)
            .WithOne(b => b.Brewery)
            .HasForeignKey(b => b.BreweryId);

        // Wholesaler has many WholesalerStocks
        modelBuilder.Entity<Wholesaler>()
            .HasMany(w => w.Stocks)
            .WithOne(s => s.Wholesaler)
            .HasForeignKey(s => s.WholesalerId);

        // Beer has many WholesalerStocks
        modelBuilder.Entity<Beer>()
            .HasMany<WholesalerStock>()
            .WithOne(s => s.Beer)
            .HasForeignKey(s => s.BeerId);
    }
}
