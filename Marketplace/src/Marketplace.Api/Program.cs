using Marketplace.Infrastructure;
using Marketplace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Получаем строку подключения из конфигурации
var connectionString = builder.Configuration.GetConnectionString("Default");

// Регистрируем инфраструктурные сервисы
builder.Services.AddInfrastructure(connectionString);

// Другие сервисы (OpenAPI, мапперы и т.д.)
builder.Services.AddOpenApi();

var app = builder.Build();

// (опционально) Применяем миграции при старте (только для dev!)
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<MarketplaceDbContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => "Marketplace API is running!");
app.Run();