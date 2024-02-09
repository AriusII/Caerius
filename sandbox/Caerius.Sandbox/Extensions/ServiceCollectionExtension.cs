using Caerius.Sandbox.Repositories;
using Caerius.Sandbox.Repositories.Interfaces;
using Caerius.Sandbox.Services;
using Caerius.Sandbox.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Caerius.Sandbox.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterDependenciesInjections(this IServiceCollection services)
    {
        _ = services
            .AddServices()
            .AddRepositories();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ISandboxService, SandboxService>();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<ISandboxRepository, SandboxRepository>();
    }
}