using Mech.Code.Dtos;
using Mech.Tests.Base;
using System.Net.Http.Json;

namespace Mech.Tests.Integration;

public class EstadiasIntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task Deve_criar_uma_nova_estadia()
    {
        // Arrange
        var client = _factory.CreateClient();
        await SeedGeneros();
        await SeedQuartos();

        var especialidadeIn = new EspecialidadeIn { Nome = "Angiorradiologia e Cirurgia Endovascular" };
        var especialidadeResponse = await client.PostAsJsonAsync("/especialidades", especialidadeIn);
        var especialidade = await especialidadeResponse.DeserializeTo<EspecialidadeOut>();
        var medico = new MedicoIn
        {
            Nome = "Dr. Gutto",
            CRM = "64684684",
            Especialidades = [especialidade.Id]
        };
        await client.PostAsJsonAsync("/medicos", medico);

        var paciente = new PacienteIn
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
        await client.PostAsJsonAsync("/pacientes", paciente);

        var estadiaIn = new EstadiaIn {
            MedicoId = 1,
            PacienteId = 1,
            QuartoId = 1,
            DataDaAdmissao = DateTime.Now,
            MotivoDaAdmissao = "Deu PT"
        };

        // Act
        var response = await client.PostAsJsonAsync("/estadias", estadiaIn);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var estadia = await response.DeserializeTo<EstadiaOut>();
        estadia.Id.Should().NotBe(0);
        estadia.MotivoDaAdmissao.Should().Be(estadiaIn.MotivoDaAdmissao);
    }

    [Test]
    public async Task Deve_retornar_todas_as_estadias()
    {
        var client = _factory.CreateClient();
        await SeedGeneros();
        await SeedQuartos();

        var especialidadeIn = new EspecialidadeIn { Nome = "Angiorradiologia e Cirurgia Endovascular" };
        var especialidadeResponse = await client.PostAsJsonAsync("/especialidades", especialidadeIn);
        var especialidade = await especialidadeResponse.DeserializeTo<EspecialidadeOut>();
        var medico = new MedicoIn
        {
            Nome = "Dr. Gutto",
            CRM = "64684684",
            Especialidades = [especialidade.Id]
        };
        await client.PostAsJsonAsync("/medicos", medico);

        var paciente = new PacienteIn
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
        await client.PostAsJsonAsync("/pacientes", paciente);

        var estadiaIn = new EstadiaIn {
            MedicoId = 1,
            PacienteId = 1,
            QuartoId = 2,
            DataDaAdmissao = DateTime.Now,
            MotivoDaAdmissao = "Parada cardíaca"
        };
        await client.PostAsJsonAsync("/estadias", estadiaIn);

        // Act
        var response = await client.GetFromJsonAsync<List<EstadiaOut>>("/estadias");

        // Assert
        response.Should().Contain(x => x.MotivoDaAdmissao == estadiaIn.MotivoDaAdmissao);
    }
}
