using Mech.Code.Dtos;
using Mech.Tests.Base;
using System.Net.Http.Json;

namespace Mech.Tests.Integration;

public class GenerosIntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task Deve_criar_um_novo_genero()
    {
        // Arrange
        var client = _factory.CreateClient();

        var data = new GeneroIn { Nome = "Feminino" };

        // Act
        var response = await client.PostAsJsonAsync("/generos", data);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var medico = await response.DeserializeTo<GeneroOut>();
        medico.Id.Should().NotBe(0);
        medico.Nome.Should().Be(data.Nome);
    }

    [Test]
    public async Task Deve_retornar_todos_os_generos()
    {
        // Arrange
        var client = _factory.CreateClient();

        var data = new GeneroIn { Nome = "Feminino" };
        await client.PostAsJsonAsync("/generos", data);

        // Act
        var response = await client.GetFromJsonAsync<List<GeneroOut>>("/generos");

        // Assert
        response.Should().Contain(x => x.Nome == data.Nome);
    }
}
