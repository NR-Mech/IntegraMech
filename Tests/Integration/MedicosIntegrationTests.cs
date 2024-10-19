using Mech.Code.Dtos;
using Mech.Tests.Base;
using System.Net.Http.Json;

namespace Mech.Tests.Integration;

public class MedicosIntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task Deve_criar_um_novo_medico()
    {
        // Arrange
        var client = _factory.CreateClient();

        var especialidadeIn = new EspecialidadeIn { Nome = "Angiorradiologia e Cirurgia Endovascular" };
        var especialidadeResponse = await client.PostAsJsonAsync("/especialidades", especialidadeIn);
        var especialidade = await especialidadeResponse.DeserializeTo<EspecialidadeOut>();

        var data = new MedicoIn
        {
            Nome = "Dr. Gutto",
            CRM = "64684684",
            Especialidades = [especialidade.Id]
        };

        // Act
        var response = await client.PostAsJsonAsync("/medicos", data);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var medico = await response.DeserializeTo<MedicoOut>();
        medico.Id.Should().NotBe(0);
        medico.Nome.Should().Be(data.Nome);
        medico.CRM.Should().Be(data.CRM);
    }

    [Test]
    public async Task Deve_retornar_todos_os_medicos()
    {
        // Arrange
        var client = _factory.CreateClient();
        var especialidadeIn = new EspecialidadeIn { Nome = "Angiorradiologia e Cirurgia Endovascular" };
        var especialidadeResponse = await client.PostAsJsonAsync("/especialidades", especialidadeIn);
        var especialidade = await especialidadeResponse.DeserializeTo<EspecialidadeOut>();

        var data = new MedicoIn
        {
            Nome = "Dr. Gutto",
            CRM = "59742635",
            Especialidades = [especialidade.Id]
        };
        await client.PostAsJsonAsync("/medicos", data);

        // Act
        var response = await client.GetFromJsonAsync<List<MedicoOut>>("/medicos");

        // Assert
        response.Should().Contain(x => x.CRM == "59742635");
    }
}
