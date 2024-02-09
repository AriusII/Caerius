namespace Cearius.ORM.DataAccess.Builders.TablesValuedParametersBuilder;

public interface ITvpBuilder<in T>
{
    SqlParameter Build(IEnumerable<T> items);
}