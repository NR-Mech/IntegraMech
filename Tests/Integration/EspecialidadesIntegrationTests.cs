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
    public async Task Deve_atualizar_uma_especialidade()
    {
        // Arrange
        var client = _factory.CreateClient();

        var dataCreate = new EspecialidadeIn { Nome = "Angiorradiologia" };
        var responseCreate = await client.PostAsJsonAsync("/especialidades", dataCreate);
        var dtoCreate = await responseCreate.DeserializeTo<EspecialidadeOut>();

        var data = new EspecialidadeIn { Nome = "Cirurgia Endovascular" };

        // Act
        var response = await client.PutAsJsonAsync($"/especialidades/{dtoCreate.Id}", data);

        // Assert
        var dto = await response.DeserializeTo<EspecialidadeOut>();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        dto.Id.Should().Be(dtoCreate.Id);
        dto.Nome.Should().Be(data.Nome);
    }

    [Test]
    public async Task Deve_buscar_todas_as_especialidades()
    {
        // Arrange
        var client = _factory.CreateClient();

        await client.PostAsJsonAsync("/especialidades", new EspecialidadeIn { Nome = "Homeopatia" });
        await client.PostAsJsonAsync("/especialidades", new EspecialidadeIn { Nome = "Angiorradiologia e Cirurgia Endovascular" });

        // Act
        var especialidades = await client.GetFromJsonAsync<List<EspecialidadeOut>>("/especialidades");

        // Assert
        especialidades.Should().Contain(x => x.Nome == "Angiorradiologia e Cirurgia Endovascular");
        especialidades.Should().Contain(x => x.Nome == "Homeopatia");
    }

    [Test]
    public async Task Deve_deletar_uma_especialidade()
    {
        // Arrange
        var client = _factory.CreateClient();

        var dataCreate = new EspecialidadeIn { Nome = "Angiorradiologia" };
        var responseCreate = await client.PostAsJsonAsync("/especialidades", dataCreate);
        var dtoCreate = await responseCreate.DeserializeTo<EspecialidadeOut>();

        // Act
        var response = await client.DeleteAsync($"/especialidades/{dtoCreate.Id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
