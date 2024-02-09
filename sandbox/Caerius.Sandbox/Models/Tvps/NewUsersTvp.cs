using System.Data;
using Caerius.ORM.DataAccess.Mappers;

namespace Caerius.Sandbox.Models.Tvps;

public sealed record NewUsersTvp(string Username, string Password) : ITvpMapper<NewUsersTvp>
{
    public DataTable MapToDataTable(IEnumerable<NewUsersTvp> items)
    {
        var dataTable = new DataTable("NewUsersTvp");
        dataTable.Columns.Add("User", typeof(string));
        dataTable.Columns.Add("Pass", typeof(string));

        foreach (var item in items)
            dataTable.Rows.Add(item.Username, item.Password);

        return dataTable;
    }
}