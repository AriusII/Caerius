using Caerius.ORM.DataAccess.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Caerius.ORM.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterCaerius(this IServiceCollection services, string connectionString)
    {
        return services
            .AddScoped<ICaeriusDbConnectionFactory, CaeriusDbConnectionFactory>(_ =>
                new CaeriusDbConnectionFactory(connectionString));
    }
}