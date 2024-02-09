using Caerius.ORM.DataAccess.Mappers;
using System.Data;

namespace Caerius.Sandbox.Models.Tvps;

public sealed record UserAgeTvp(Guid Guid, short Age)
    : ITvpMapper<UserAgeTvp>
{
    public DataTable MapToDataTable(IEnumerable<UserAgeTvp> items)
    {
        DataTable dataTable = new();
        _ = dataTable.Columns.Add("Guid", typeof(Guid));
        _ = dataTable.Columns.Add("Age", typeof(short));

        foreach (UserAgeTvp item in items)
        {
            _ = dataTable.Rows.Add(item.Guid, item.Age);
        }

        return dataTable;
    }
}