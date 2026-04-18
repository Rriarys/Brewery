using BrewChain.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewChain.Data;

public class BrewChainDbContext : DbContext
{
    public BrewChainDbContext(DbContextOptions<BrewChainDbContext> options) : base(options) { }

    // DbSet properties to represent the tables in the database
    public DbSet<Brewery> Breweries => Set<Brewery>();
    public DbSet<BreweryStock> BreweryStocks => Set<BreweryStock>();
    public DbSet<Beer> Beers => Set<Beer>();
    public DbSet<Wholesaler> Wholesalers => Set<Wholesaler>();
    public DbSet<WholesalerStock> WholesalerStocks => Set<WholesalerStock>();
    public DbSet<Shop> Shops => Set<Shop>();
    public DbSet<ShopStock> ShopStocks => Set<ShopStock>();

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure primary keys
        modelBuilder.Entity<Brewery>().HasKey(b => b.Id);
        modelBuilder.Entity<Beer>().HasKey(b => b.Id);
        modelBuilder.Entity<Wholesaler>().HasKey(w => w.Id);
        modelBuilder.Entity<WholesalerStock>().HasKey(s => s.Id);
        modelBuilder.Entity<BreweryStock>().HasKey(s => s.Id);
        modelBuilder.Entity<Shop>().HasKey(s => s.Id);
        modelBuilder.Entity<ShopStock>().HasKey(s => s.Id);

        // Brewery has many Beers
        modelBuilder.Entity<Brewery>()
            .HasMany(b => b.Beers)
            .WithOne(b => b.Brewery)
            .HasForeignKey(b => b.BreweryId);

        // Brewery has many BreweryStocks
        modelBuilder.Entity<Brewery>()
            .HasMany(b => b.BreweryStocks)
            .WithOne(s => s.Brewery)
            .HasForeignKey(s => s.BreweryId);

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
        
        // Beer has many ShopStocks
        modelBuilder.Entity<Beer>()
            .HasMany<ShopStock>()
            .WithOne(ss => ss.Beer)
            .HasForeignKey(ss => ss.BeerId);

        // Beer has many BreweryStocks
        modelBuilder.Entity<Beer>()
            .HasMany<BreweryStock>()
            .WithOne(bs => bs.Beer)
            .HasForeignKey(bs => bs.BeerId);

        // Shop has many ShopStocks
        modelBuilder.Entity<Shop>()
            .HasMany(s => s.ShopStocks)
            .WithOne(ss => ss.Shop)
            .HasForeignKey(ss => ss.ShopId);
    }
}
