namespace Caerius.ORM.DataAccess.Factories;

public interface ICaeriusDbConnectionFactory
{
    IDbConnection CreateConnection();
}