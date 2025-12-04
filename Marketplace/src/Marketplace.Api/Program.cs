using Marketplace.Infrastructure;
using Marketplace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Marketplace API",
        Version = "v1",
        Description = "A marketplace backend API for products, inventory, and sellers."
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<MarketplaceDbContext>();
    context.Database.Migrate();
    app.MapOpenApi();
    
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marketplace API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapGet("/", () => "Marketplace API is running!");
app.Run();