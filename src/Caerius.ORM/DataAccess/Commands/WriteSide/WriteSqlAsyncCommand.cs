using Caerius.ORM.DataAccess.Factories;
using Caerius.ORM.Models;

namespace Caerius.ORM.DataAccess.Commands.WriteSide;

public static class WriteSqlAsyncCommand
{
    public static async Task ExecuteScalarAsync(this ICaeriusDbConnectionFactory connectionFactory,
        StoredProcedureRequestModel request)
    {
        try
        {
            IDbConnection connection = connectionFactory.CreateConnection();

            using (connection)
            {
                await using SqlCommand command = new(request.ProcedureName, connection as SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange([.. request.Parameters]);

                _ = await command.ExecuteScalarAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to execute command for stored procedure : {request.ProcedureName}", ex);
        }
    }

    public static async Task<int> ExecuteAsync(this ICaeriusDbConnectionFactory connectionFactory,
        StoredProcedureRequestModel request)
    {
        try
        {
            IDbConnection connection = connectionFactory.CreateConnection();

            using (connection)
            {
                await using SqlCommand command = new(request.ProcedureName, connection as SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange([.. request.Parameters]);

                return await command.ExecuteNonQueryAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to execute command for stored procedure : {request.ProcedureName}", ex);
        }
    }
}