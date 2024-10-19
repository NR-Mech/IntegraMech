using Mech.Domain;

namespace Mech.Tests.Unit;

public class PacienteUnitTests
{
    [Test]
    public void Deve_criar_um_paciente()
    {
        // Arrange

        const long generoId = 1;
        const long cidadeId = 2;
        const string cpf = "05531923023";
        const string cns = "4684686781";
        const string nome = "Reginaldo Rossi";
        var dataDeNascimento = new DateOnly(1944, 02, 14);
        const string cep = "55106500";
        const string rua = "Rua Maria Alpina II";
        const string bairro = "Nassal Miranda";

        // Act
        var paciente = new Paciente(nome, cpf, cns, dataDeNascimento, generoId, cidadeId, cep, rua, bairro);

        // Assert
        paciente.Nome.Should().Be(nome);
        paciente.CPF.Should().Be(cpf);
        paciente.CNS.Should().Be(cns);
        paciente.DataDeNascimento.Should().Be(dataDeNascimento);
        paciente.GeneroId.Should().Be(generoId);
        paciente.Endereco.CidadeId.Should().Be(cidadeId);
        paciente.Endereco.CEP.Should().Be(cep);
        paciente.Endereco.Rua.Should().Be(rua);
        paciente.Endereco.Bairro.Should().Be(bairro);
    }
}
