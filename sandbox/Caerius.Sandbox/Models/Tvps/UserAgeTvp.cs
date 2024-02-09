using System.Data;
using Caerius.ORM.DataAccess.Mappers;

namespace Caerius.Sandbox.Models.Tvps;

public sealed record UserAgeTvp(Guid Guid, short Age)
    : ITvpMapper<UserAgeTvp>
{
    public DataTable MapToDataTable(IEnumerable<UserAgeTvp> items)
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("Guid", typeof(Guid));
        dataTable.Columns.Add("Age", typeof(short));

        foreach (var item in items) dataTable.Rows.Add(item.Guid, item.Age);

        return dataTable;
    }
}