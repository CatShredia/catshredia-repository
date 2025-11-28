using Marketplace.Infrastructure;
using Marketplace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

if (args.Contains("--migrate-only"))
{
    var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .AddJsonFile($"appsettings.Development.json", optional: true)
        .AddEnvironmentVariables()
        .Build();

    var migrationString = config.GetConnectionString("Default");

    var services = new ServiceCollection();
    services.AddDbContext<MarketplaceDbContext>(opt =>
        opt.UseNpgsql(migrationString));

    using var scope = services.BuildServiceProvider().CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<MarketplaceDbContext>();
    context.Database.Migrate();
    Console.WriteLine("Migrations applied. Exiting.");
    return;
}

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<MarketplaceDbContext>();
    context.Database.Migrate();
    app.MapOpenApi();
}

app.MapGet("/", () => "Marketplace API is running!");
app.Run();