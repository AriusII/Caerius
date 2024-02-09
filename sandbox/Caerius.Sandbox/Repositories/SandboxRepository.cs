using Caerius.ORM.DataAccess.Commands.ReadSide;
using Caerius.ORM.DataAccess.Commands.WriteSide;
using Caerius.ORM.DataAccess.Factories;
using Caerius.ORM.Models;
using Caerius.Sandbox.Models.Dtos;
using Caerius.Sandbox.Models.Tvps;
using Caerius.Sandbox.Repositories.Interfaces;

namespace Caerius.Sandbox.Repositories;

public sealed record SandboxRepository(ICaeriusDbConnectionFactory Connection) : ISandboxRepository
{
    public string GetSandboxMessage()
    {
        return "Hello from the sandbox!";
    }

    public async Task<IEnumerable<UsersDto>> GetUsers()
    {
        StoredProcedureRequest spParameters = new("dbo.sp_get_users");
        IEnumerable<UsersDto> users = await Connection.QueryAsync<UsersDto>(spParameters);
        return users;
    }

    public async Task CreateListOfUsers(IEnumerable<NewUsersTvp> users)
    {
        StoredProcedureRequest spParameters = new StoredProcedureRequest("dbo.sp_create_user_with_tvp")
            .AddTableValuedParameter("@MyTvpUsers", "dbo.tvp_newUsers", users);

        int dbResult = await Connection.ExecuteAsync(spParameters);

        Console.WriteLine($"Inserted {dbResult} users");
    }

    public Task UpdateRandomUserAge(IEnumerable<UserAgeTvp> users)
    {
        StoredProcedureRequest spParameters = new StoredProcedureRequest("dbo.sp_update_user_age")
            .AddTableValuedParameter("@MyTvpUserAge", "dbo.tvp_usersAge", users);
        return Connection.ExecuteScalarAsync(spParameters);
    }
}