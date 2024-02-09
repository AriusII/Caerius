namespace Caerius.ORM.DataAccess.Mappers;

public interface ITvpMapper<in T>
    where T : class
{
    DataTable MapToDataTable(IEnumerable<T> items);
}