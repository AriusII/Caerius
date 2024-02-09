namespace Cearius.ORM.DataAccess.Mappers;

public interface ITvpMapper<in T> : IDisposable
    where T : class
{
    DataTable MapToDataTable(IEnumerable<T> items);
}