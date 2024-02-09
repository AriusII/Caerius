namespace Caerius.ORM.DataAccess.Factories;

public interface ICeariusDbConnectionFactory
{
    IDbConnection CreateConnection();
}