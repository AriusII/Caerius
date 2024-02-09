using Cearius.ORM.Models;

namespace Cearius.ORM.DataAccess.Builders.StoredProcedureBuilder;

public interface IStoredProcedureBuilder
{
    StoredProcedureBuilder AddParameter(string name, object value, SqlDbType type);
    StoredProcedureRequest Build();
}