using Caerius.ORM.DataAccess.Mappers;
using System.Data;

namespace Caerius.Sandbox.Models.Tvps;

public sealed record NewUsersTvp(string Username, string Password) : ITvpMapper<NewUsersTvp>
{
    public DataTable MapToDataTable(IEnumerable<NewUsersTvp> items)
    {
        DataTable dataTable = new("NewUsersTvp");
        _ = dataTable.Columns.Add("User", typeof(string));
        _ = dataTable.Columns.Add("Pass", typeof(string));

        foreach (NewUsersTvp item in items)
        {
            _ = dataTable.Rows.Add(item.Username, item.Password);
        }

        return dataTable;
    }
}