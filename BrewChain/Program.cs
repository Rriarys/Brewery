using BrewChain.Data;
using BrewChain.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog logging
builder.Host.AddSerilogLogging();

// Add Db context with connection string from configuration
builder.Services.AddBrewChainDbContext(builder.Configuration);

// Add controllers for API endpoints
builder.Services.AddControllers();

var app = builder.Build();

// Use Serilog request logging middleware to log HTTP requests and responses
app.UseSerilogRequestLogging();

// Apply any pending migrations to the database
app.MigrateDatabase();

 // Seed the database with initial data if necessary (checking Breweries table to avoid duplicate seeding)
app.SeedDatabase();

app.MapControllers();

app.Run();
