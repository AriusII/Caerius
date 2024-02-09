using Caerius.Sandbox.Models.Dtos;
using Caerius.Sandbox.Models.Tvps;
using Caerius.Sandbox.Repositories.Interfaces;
using Caerius.Sandbox.Services.Interfaces;

namespace Caerius.Sandbox.Services;

public sealed record SandboxService(ISandboxRepository SandboxRepository) : ISandboxService
{
    private readonly Random _random = new();

    public string GetSandboxMessage()
    {
        return "Hello from the sandbox!";
    }

    public async Task<IEnumerable<UsersDto>> GetUsers()
    {
        return await SandboxRepository.GetUsers();
    }

    public Task CreateListOfUsers()
    {
        const int increment = 0;

        List<NewUsersTvp> usersToCreate =
            Enumerable
                .Range(1, _random.Next(1, 2500))
                .Select(i =>
                    new NewUsersTvp(
                        $"user{i + increment}",
                        "pass"))
                .ToList();

        return SandboxRepository.CreateListOfUsers(usersToCreate);
    }

    public Task UpdateRandomUserAge(IEnumerable<UsersDto> users)
    {
        List<UserAgeTvp> usersToUpdate =
            users
                .OrderBy(_ => _random.Next())
                .Take(50)
                .Select(u =>
                    new UserAgeTvp(
                        u.Guid,
                        (short)_random.Next(3, 20)))
                .ToList();

        return SandboxRepository.UpdateRandomUserAge(usersToUpdate);
    }
}