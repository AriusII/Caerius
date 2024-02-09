using Caerius.Sandbox.Models.Dtos;
using Caerius.Sandbox.Models.Tvps;

namespace Caerius.Sandbox.Repositories.Interfaces;

public interface ISandboxRepository
{
    string GetSandboxMessage();
    Task<IEnumerable<UsersDto>> GetUsers();
    Task CreateListOfUsers(IEnumerable<NewUsersTvp> users);
    Task UpdateRandomUserAge(IEnumerable<UserAgeTvp> users);
}