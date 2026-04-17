using BrewChain.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Db context with connection string from configuration
builder.Services.AddBrewChainDbContext(builder.Configuration);

// Add controllers for API endpoints
builder.Services.AddControllers();

var app = builder.Build();

// Apply any pending migrations to the database
app.MigrateDatabase();

app.MapControllers();

app.Run();
