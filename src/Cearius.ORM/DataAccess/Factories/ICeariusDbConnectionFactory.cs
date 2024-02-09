namespace Cearius.ORM.DataAccess.Factories;

public interface ICeariusDbConnectionFactory
{
    IDbConnection CreateConnection();
}