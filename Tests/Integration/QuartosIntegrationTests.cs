using Mech.Code.Dtos;
using Mech.Tests.Base;
using System.Net.Http.Json;

namespace Mech.Tests.Integration;

public class QuartosIntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task Deve_retornar_todos_os_quartos()
    {
        // Arrange
        var client = _factory.CreateClient();
        await SeedQuartos();

        // Act
        var response = await client.GetFromJsonAsync<List<QuartoOut>>("/quartos");

        // Assert
        response.Should().HaveCount(3);
    }
}
