﻿using Caerius.ORM.DataAccess.Mappers;

namespace Caerius.ORM.Models;

public sealed record StoredProcedureRequest(string ProcedureName)
{
    public string ProcedureName { get; } = ProcedureName;
    public List<SqlParameter> Parameters { get; } = [];

    public StoredProcedureRequest AddStoredProcedureParameter(string name, object value, SqlDbType type)
    {
        Parameters.Add(new SqlParameter(name, type) { Value = value });
        return this;
    }

    public StoredProcedureRequest AddTableValuedParameter<T>(string parameterName, string tvpName, IEnumerable<T> items)
        where T : class, ITvpMapper<T>
    {
        var tvp = items.FirstOrDefault();
        if (tvp is null) throw new ArgumentException("No items to map to Table-Valued Parameters");

        var dataTable = tvp.MapToDataTable(items);
        var parameter = new SqlParameter(parameterName, SqlDbType.Structured)
        {
            TypeName = tvpName,
            Value = dataTable
        };

        Parameters.Add(parameter);
        return this;
    }
}