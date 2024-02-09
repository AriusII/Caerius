namespace Caerius.ORM.DataAccess.Factories;

public sealed record CaeriusDbConnectionFactory(string ConnectionString)
    : ICaeriusDbConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        try
        {
            SqlConnection connection = new(ConnectionString);
            connection.Open();
            return connection;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to open database connection", ex);
        }
    }
}