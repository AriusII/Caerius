namespace Caerius.ORM.DataAccess.Mappers;

public interface ISpMapper<out T>
    where T : class
{
    static abstract T MapFromReader(SqlDataReader reader);
}