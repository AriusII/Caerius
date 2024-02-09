using Caerius.ORM.DataAccess.Factories;
using Caerius.ORM.DataAccess.Mappers;
using Caerius.ORM.Models;

namespace Caerius.ORM.DataAccess.Commands.ReadSide;

public static class ReadSqlAsyncCommands
{
    public static async Task<ImmutableArray<T>> ImmutableQueryAsync<T>(
        this ICeariusDbConnectionFactory connectionFactory,
        StoredProcedureRequest request)
        where T : class, ISpMapper<T>
    {
        try
        {
            var connection = connectionFactory.CreateConnection();

            using (connection)
            {
                await using var command = new SqlCommand(request.ProcedureName, connection as SqlConnection);
                command.Parameters.AddRange(request.Parameters.ToArray());
                command.CommandType = CommandType.StoredProcedure;

                var results = ImmutableArray.CreateBuilder<T>();
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                    results.Add(T.MapFromReader(reader));

                return results.ToImmutable();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to execute query for stored procedure : {request.ProcedureName}", ex);
        }
    }

    public static async Task<IEnumerable<T>> QueryAsync<T>(this ICeariusDbConnectionFactory connectionFactory,
        StoredProcedureRequest request)
        where T : class, ISpMapper<T>
    {
        try
        {
            var connection = connectionFactory.CreateConnection();

            using (connection)
            {
                await using var command = new SqlCommand(request.ProcedureName, connection as SqlConnection);
                command.Parameters.AddRange(request.Parameters.ToArray());
                command.CommandType = CommandType.StoredProcedure;

                var results = new List<T>();
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                    results.Add(T.MapFromReader(reader));

                return results.AsEnumerable();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to execute query for stored procedure : {request.ProcedureName}", ex);
        }
    }

    public static async Task<T?> FirstOrDefaultAsync<T>(this ICeariusDbConnectionFactory connectionFactory,
        StoredProcedureRequest request)
        where T : class, ISpMapper<T>
    {
        try
        {
            var connection = connectionFactory.CreateConnection();

            using (connection)
            {
                await using var command = new SqlCommand(request.ProcedureName, connection as SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(request.Parameters.ToArray());

                var results = ImmutableArray.CreateBuilder<T>();

                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                    results.Add(T.MapFromReader(reader));

                return results.FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to execute query for stored procedure : {request.ProcedureName}", ex);
        }
    }
}