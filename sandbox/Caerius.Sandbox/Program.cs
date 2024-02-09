using Caerius.ORM.Extensions;
using Caerius.Sandbox.Extensions;
using Caerius.Sandbox.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#region > Dependency Injection Container

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .Build();

services.AddSingleton<IConfiguration>(configuration);

var connectionString = configuration.GetConnectionString("SandboxConnection");

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

var serviceProvider = services.BuildServiceProvider();

#endregion

var sandboxService = serviceProvider.GetRequiredService<ISandboxService>();

await sandboxService.CreateListOfUsers();

var users = await sandboxService.GetUsers();

await sandboxService.UpdateRandomUserAge(users);

Console.ReadLine();