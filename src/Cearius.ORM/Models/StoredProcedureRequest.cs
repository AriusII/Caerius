namespace Cearius.ORM.Models;

public sealed record StoredProcedureRequest(string ProcedureName)
{
    public string ProcedureName { get; } = ProcedureName;
    public List<SqlParameter> Parameters { get; } = [];

    public void AddParameter(string name, object value, SqlDbType type)
    {
        Parameters.Add(new SqlParameter(name, type) { Value = value });
    }
}