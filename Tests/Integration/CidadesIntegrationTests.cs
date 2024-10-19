using Mech.Code.Dtos;
using Mech.Tests.Base;
using System.Net.Http.Json;

namespace Mech.Tests.Integration;

public class CidadesIntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task Deve_retornar_todas_as_cidades()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetFromJsonAsync<List<CidadeOut>>("/cidades");

        // Assert
        response.Should().HaveCount(4);
    }
}
