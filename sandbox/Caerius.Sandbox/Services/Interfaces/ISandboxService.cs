using Caerius.Sandbox.Models.Dtos;

namespace Caerius.Sandbox.Services.Interfaces;

public interface ISandboxService
{
    string GetSandboxMessage();
    Task<IEnumerable<UsersDto>> GetUsers();
    Task CreateListOfUsers();
    Task UpdateRandomUserAge(IEnumerable<UsersDto> users);
}