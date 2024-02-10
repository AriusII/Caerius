using Caerius.ORM.Models;

namespace Caerius.UnitTests.Models;

public sealed class StoredProcedureRequestModelShould
{
    [Theory]
    [AutoData]
    public void BeCreatedWithValidParameters(string storedProcedureName, object parameters)
    {
        // Arrange
        StoredProcedureRequestModel request = new(storedProcedureName);

        // Act
        _ = request.AddStoredProcedureParameter("param1", parameters, SqlDbType.Int);

        // Assert
        Assert.Equal(storedProcedureName, request.ProcedureName);
        Assert.NotEmpty(request.Parameters);
    }
}