using Caerius.ORM.DataAccess.Factories;
using Caerius.ORM.Models;

namespace Caerius.ORM.DataAccess.Commands.WriteSide;

public static class WriteSqlAsyncCommands
{
    public static async Task ExecuteScalarAsync(this ICeariusDbConnectionFactory connectionFactory,
        StoredProcedureRequest request)
    {
        try
        {
            var connection = connectionFactory.CreateConnection();

            using (connection)
            {
                await using var command = new SqlCommand(request.ProcedureName, connection as SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(request.Parameters.ToArray());

                await command.ExecuteScalarAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to execute command for stored procedure : {request.ProcedureName}", ex);
        }
    }

    public static async Task<int> ExecuteAsync(this ICeariusDbConnectionFactory connectionFactory,
        StoredProcedureRequest request)
    {
        try
        {
            var connection = connectionFactory.CreateConnection();

            using (connection)
            {
                await using var command = new SqlCommand(request.ProcedureName, connection as SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(request.Parameters.ToArray());

                return await command.ExecuteNonQueryAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to execute command for stored procedure : {request.ProcedureName}", ex);
        }
    }
}