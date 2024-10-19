using Mech.Domain;

namespace Mech.Tests.Unit;

public class DepartamentoUnitTests
{
    [Test]
    public void Deve_criar_um_departamento()
    {
        // Arrange
        const string nome = "Urgência e Emergência";
        const string descricao = "Departamento de Urgência e Emergência";

        // Act
        var departamento = new Departamento(nome, descricao);

        // Assert
        departamento.Nome.Should().Be(nome);
        departamento.Descricao.Should().Be(descricao);
    }

    [Test]
    public void Deve_converter_um_departamento_pro_out()
    {
        // Arrange
        const string nome = "Urgência e Emergência";
        const string descricao = "Departamento de Urgência e Emergência";
        var departamento = new Departamento(nome, descricao);

        // Act
        var dto = departamento.ToOut();

        // Assert
        dto.Id.Should().Be(departamento.Id);
        dto.Nome.Should().Be(departamento.Nome);
        dto.Descricao.Should().Be(departamento.Descricao);
    }
}
