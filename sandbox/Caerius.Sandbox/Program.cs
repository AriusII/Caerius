using Caerius.Sandbox.Extensions;
using Caerius.Sandbox.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#region > Dependency Injection Container

ServiceCollection services = new();

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .Build();

services.AddSingleton<IConfiguration>(configuration);

string? connectionString = configuration.GetConnectionString("SandboxConnection");

if (connectionString != null)
{
    services
        .RegisterCearius(connectionString)
        .RegisterDependenciesInjections();
}
else
{
    Console.WriteLine("No connection string found in appsettings.json");

    services.RegisterDependenciesInjections();
}

ServiceProvider serviceProvider = services.BuildServiceProvider();

#endregion

ISandboxService sandboxService = serviceProvider.GetRequiredService<ISandboxService>();

await sandboxService.CreateListOfUsers();

IEnumerable<Caerius.Sandbox.Models.Dtos.UsersDto> users = await sandboxService.GetUsers();

await sandboxService.UpdateRandomUserAge(users);

Console.ReadLine();