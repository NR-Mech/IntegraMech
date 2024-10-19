using Mech.Domain;

namespace Mech.Tests.Unit;

public class EspecialidadeUnitTests
{
    [Test]
    public void Deve_criar_uma_especialidade()
    {
        // Arrange
        const string nome = "Cardiologia";

        // Act
        var especialidade = new Especialidade(nome);

        // Assert
        especialidade.Nome.Should().Be(nome);
    }

    [Test]
    public void Deve_atualizar_uma_especialidade()
    {
        // Arrange
        const string novoNome = "Homeopatia";
        var especialidade = new Especialidade("Cardiologia");

        // Act
        especialidade.Update(novoNome);

        // Assert
        especialidade.Nome.Should().Be(novoNome);
    }

    [Test]
    public void Deve_converter_uma_especialidade_pro_out()
    {
        // Arrange
        var especialidade = new Especialidade("Cardiologia");

        // Act
        var dto = especialidade.ToOut();

        // Assert
        dto.Id.Should().Be(especialidade.Id);
        dto.Nome.Should().Be(especialidade.Nome);
    }
}
