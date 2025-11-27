using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Persistence;

public class MarketplaceDbContext : DbContext
{
    public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options)
        : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     base.OnModelCreating(builder);
    //     builder.HasPostgresEnum<TxnType>();
    //     // Настройки индексов, уникальности, связей — здесь или в Configurations/
    // }
}