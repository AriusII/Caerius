using Cearius.ORM.DataAccess.Mappers;

namespace Cearius.ORM.DataAccess.Builders.TablesValuedParametersBuilder;

public sealed record TvpBuilder<T>(string ParameterName, string TvpTypeName, ITvpMapper<T> Mapper)
    : ITvpBuilder<T>, IDisposable
    where T : class
{
    public void Dispose()
    {
        Mapper.Dispose();
        GC.SuppressFinalize(this);
    }

    public SqlParameter Build(IEnumerable<T> items)
    {
        var dataTable = Mapper.MapToDataTable(items);
        return new SqlParameter
        {
            ParameterName = ParameterName,
            SqlDbType = SqlDbType.Structured,
            TypeName = TvpTypeName,
            Value = dataTable
        };
    }
}