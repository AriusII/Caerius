using Caerius.ORM.DataAccess.Factories;
using Caerius.ORM.DataAccess.Mappers;
using Caerius.ORM.Models;

namespace Caerius.ORM.DataAccess.Commands.ReadSide;

public static class ReadSqlAsyncCommands
{
    public static async Task<ImmutableArray<T>> ImmutableQueryAsync<T>(
        this ICaeriusDbConnectionFactory connectionFactory,
        StoredProcedureRequest request)
        where T : class, ISpMapper<T>
    {
        try
        {
            IDbConnection connection = connectionFactory.CreateConnection();

            using (connection)
            {
                await using SqlCommand command = new(request.ProcedureName, connection as SqlConnection);
                command.Parameters.AddRange([.. request.Parameters]);
                command.CommandType = CommandType.StoredProcedure;

                ImmutableArray<T>.Builder results = ImmutableArray.CreateBuilder<T>();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    results.Add(T.MapFromReader(reader));
                }

                return results.ToImmutable();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to execute query for stored procedure : {request.ProcedureName}", ex);
        }
    }

    public static async Task<IEnumerable<T>> QueryAsync<T>(this ICaeriusDbConnectionFactory connectionFactory,
        StoredProcedureRequest request)
        where T : class, ISpMapper<T>
    {
        try
        {
            IDbConnection connection = connectionFactory.CreateConnection();

            using (connection)
            {
                await using SqlCommand command = new(request.ProcedureName, connection as SqlConnection);
                command.Parameters.AddRange([.. request.Parameters]);
                command.CommandType = CommandType.StoredProcedure;

                List<T> results = [];
                await using SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    results.Add(T.MapFromReader(reader));
                }

                return results.AsEnumerable();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to execute query for stored procedure : {request.ProcedureName}", ex);
        }
    }

    public static async Task<T?> FirstOrDefaultAsync<T>(this ICaeriusDbConnectionFactory connectionFactory,
        StoredProcedureRequest request)
        where T : class, ISpMapper<T>
    {
        try
        {
            IDbConnection connection = connectionFactory.CreateConnection();

            using (connection)
            {
                await using SqlCommand command = new(request.ProcedureName, connection as SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange([.. request.Parameters]);

                ImmutableArray<T>.Builder results = ImmutableArray.CreateBuilder<T>();

                await using SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    results.Add(T.MapFromReader(reader));
                }

                return results.FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to execute query for stored procedure : {request.ProcedureName}", ex);
        }
    }
}