using Mech.Code.Dtos;
using Mech.Tests.Base;
using System.Net.Http.Json;

namespace Mech.Tests.Integration;

public class DepartamentosIntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task Deve_criar_um_novo_departamento()
    {
        // Arrange
        var client = _factory.CreateClient();

        var data = new DepartamentoIn
        {
            Nome = "Urgência e Emergência", Descricao = "Departamento responsável por Urgência e Emergência"
        };

        // Act
        var response = await client.PostAsJsonAsync("/departamentos", data);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var departamento = await response.DeserializeTo<DepartamentoOut>();
        departamento.Id.Should().NotBe(0);
        departamento.Nome.Should().Be(data.Nome);
        departamento.Descricao.Should().Be(data.Descricao);
    }

    [Test]
    public async Task Deve_buscar_todos_os_departamentos()
    {
        // Arrange
        var client = _factory.CreateClient();

        var dept00 = new DepartamentoIn
        {
            Nome = "Urgência e Emergência", Descricao = "Departamento responsável por Urgência e Emergência"
        };
        await client.PostAsJsonAsync("/departamentos", dept00);

        var dept01 = new DepartamentoIn
        {
            Nome = "Recursos Humanos", Descricao = "Departamento responsável por Recursos Humanos"
        };
        await client.PostAsJsonAsync("/departamentos", dept01);

        var dept02 = new DepartamentoIn
        {
            Nome = "Apoio Terapêutico", Descricao = "Departamento responsável por Apoio Terapêutico"
        };
        await client.PostAsJsonAsync("/departamentos", dept02);

        // Act
        var departamentos = await client.GetFromJsonAsync<List<DepartamentoOut>>("/departamentos") ?? [];

        // Assert
        departamentos[0].Nome.Should().Be("Apoio Terapêutico");
        departamentos[1].Nome.Should().Be("Recursos Humanos");
        departamentos[2].Nome.Should().Be("Urgência e Emergência");
    }
}
