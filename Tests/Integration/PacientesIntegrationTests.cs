using Mech.Code.Dtos;
using Mech.Tests.Base;
using System.Net.Http.Json;

namespace Mech.Tests.Integration;

public class PacientesIntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task Deve_criar_um_novo_paciente()
    {
        // Arrange
        var client = _factory.CreateClient();
        await SeedGeneros();

        var data = new PacienteIn
        {
            GeneroId = 2,
            CidadeId = 1,
            Cpf = "29328343046",
            CNS = "6186168168",
            Nome = "Faustão",
            DataDeNascimento = "05/12/2004",
            CEP = "55106500",
            Rua = "Rua Maria Alpina II",
            Bairro = "Nassal Miranda",
        };

        // Act
        var response = await client.PostAsJsonAsync("/pacientes", data);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var paciente = await response.DeserializeTo<PacienteOut>();
        paciente.Id.Should().NotBe(0);
        paciente.Cpf.Should().Be(data.Cpf);
        paciente.CNS.Should().Be(data.CNS);
        paciente.Nome.Should().Be(data.Nome);
    }

    [Test]
    public async Task Deve_retornar_todos_os_pacientes()
    {
        // Arrange
        var client = _factory.CreateClient();
        await SeedGeneros();

        var data = new PacienteIn
        {
            GeneroId = 2,
            CidadeId = 1,
            Cpf = "15975365489",
            CNS = "6186168168",
            Nome = "Faustão",
            DataDeNascimento = "05/12/2004",
            CEP = "55106500",
            Rua = "Rua Maria Alpina II",
            Bairro = "Nassal Miranda",
        };
        await client.PostAsJsonAsync("/pacientes", data);

        // Act
        var response = await client.GetFromJsonAsync<List<PacienteOut>>("/pacientes");

        // Assert
        response.Should().Contain(x => x.Cpf == data.Cpf);
    }
}
