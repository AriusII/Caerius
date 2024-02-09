namespace Cearius.ORM.DataAccess.Factories;

public sealed record CeariusCeariusDbConnectionFactory(string ConnectionString)
    : ICeariusDbConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        try
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to open database connection", ex);
        }
    }
}