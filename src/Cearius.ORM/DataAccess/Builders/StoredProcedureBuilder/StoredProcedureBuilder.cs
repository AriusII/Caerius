using Cearius.ORM.Models;

namespace Cearius.ORM.DataAccess.Builders.StoredProcedureBuilder;

public sealed record StoredProcedureBuilder(string ProcedureName) : IStoredProcedureBuilder
{
    private readonly StoredProcedureRequest _request = new(ProcedureName);

    public StoredProcedureBuilder AddParameter(string name, object value, SqlDbType type)
    {
        _request.AddParameter(name, value, type);
        return this;
    }

    public StoredProcedureRequest Build()
    {
        return _request;
    }
}