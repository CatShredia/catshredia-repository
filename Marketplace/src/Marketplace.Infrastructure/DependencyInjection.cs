using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Marketplace.Infrastructure.Persistence;

namespace Marketplace.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MarketplaceDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}