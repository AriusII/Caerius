using Caerius.ORM.DataAccess.Mappers;
using Microsoft.Data.SqlClient;

namespace Caerius.Sandbox.Models.Dtos;

public sealed record UsersDto(Guid Guid, string User, string Pass, short Age) : ISpMapper<UsersDto>
{
    public static UsersDto MapFromReader(SqlDataReader reader)
    {
        return new UsersDto(
            reader.GetGuid(0),
            reader.GetString(1),
            reader.GetString(2),
            (short)reader.GetSqlByte(3)
        );
    }
}