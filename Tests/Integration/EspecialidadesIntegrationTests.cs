using Mech.Code.Dtos;
using Mech.Tests.Base;
using System.Net.Http.Json;

namespace Mech.Tests.Integration;

public class EspecialidadesIntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task Deve_criar_uma_nova_especialidade()
    {
        // Arrange
        var client = _factory.CreateClient();

        var data = new EspecialidadeIn { Nome = "Angiorradiologia e Cirurgia Endovascular" };

        // Act
        var response = await client.PostAsJsonAsync("/especialidades", data);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var dto = await response.DeserializeTo<EspecialidadeOut>();
        dto.Id.Should().NotBe(0);
        dto.Nome.Should().Be(data.Nome);
    }

    [Test]
    public async Task Deve_buscar_todas_as_especialidades_ordenadas_alfabeticamente()
    {
        // Arrange
        var client = _factory.CreateClient();

        await client.PostAsJsonAsync("/especialidades", new EspecialidadeIn { Nome = "Homeopatia" });
        await client.PostAsJsonAsync("/especialidades", new EspecialidadeIn { Nome = "Angiorradiologia e Cirurgia Endovascular" });

        // Act
        var especialidades = await client.GetFromJsonAsync<List<EspecialidadeOut>>("/especialidades");

        // Assert
        especialidades![0].Nome.Should().Be("Angiorradiologia e Cirurgia Endovascular");
        especialidades![1].Nome.Should().Be("Homeopatia");
    }
}
