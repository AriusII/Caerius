using Caerius.ORM.DataAccess.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Caerius.ORM.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterCearius(this IServiceCollection services, string connectionString)
    {
        return services
            .AddScoped<ICeariusDbConnectionFactory, CeariusCeariusDbConnectionFactory>(_ =>
                new CeariusCeariusDbConnectionFactory(connectionString));
    }
}