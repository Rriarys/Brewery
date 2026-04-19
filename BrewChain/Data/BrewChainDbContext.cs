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
    public DbSet<Wallet> Wallets => Set<Wallet>();

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
        modelBuilder.Entity<Wallet>().HasKey(w => w.Id);

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

        //Brewery has one Wallet
        modelBuilder.Entity<Brewery>()
            .HasOne(b => b.Wallet)
            .WithOne()
            .HasForeignKey<Brewery>(b => b.WalletId);

        // Ensure Country is stored in uppercase for consistency
        modelBuilder.Entity<Brewery>()
            .Property(b => b.Country)
            .HasMaxLength(2) // ISO country codes are 2 characters
            .HasConversion(
                v => v.ToUpper(), // Into database
                v => v.ToUpper()  // From database
            );

        // Wholesaler has many WholesalerStocks
        modelBuilder.Entity<Wholesaler>()
            .HasMany(w => w.Stocks)
            .WithOne(s => s.Wholesaler)
            .HasForeignKey(s => s.WholesalerId);

        // Wholesaler has one Wallet
        modelBuilder.Entity<Wholesaler>()
            .HasOne(w => w.Wallet)
            .WithOne()
            .HasForeignKey<Wholesaler>(w => w.WalletId);

        // Ensure Country is stored in uppercase for consistency
        modelBuilder.Entity<Wholesaler>()
            .Property(w => w.Country)
            .HasMaxLength(2)
            .HasConversion(
                v => v.ToUpper(),
                v => v.ToUpper()
            );

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

        // Shop has one Wallet
        modelBuilder.Entity<Shop>()
            .HasOne(s => s.Wallet)
            .WithOne()
            .HasForeignKey<Shop>(s => s.WalletId);

        // Ensure Country is stored in uppercase for consistency
        modelBuilder.Entity<Shop>()
            .Property(s => s.Country)
            .HasMaxLength(2)
            .HasConversion(
                v => v.ToUpper(),
                v => v.ToUpper()
            );
    }
}
