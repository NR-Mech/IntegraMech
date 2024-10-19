using Mech.Domain;

namespace Mech.Tests.Unit;

public class MedicoUnitTests
{
    [Test]
    public void Deve_criar_um_medico()
    {
        // Arrange
        const string nome = "Dr. Chico Science";
        const string crm = "159753/PE";

        // Act
        var medico = new Medico(nome, crm);

        // Assert
        medico.Nome.Should().Be(nome);
        medico.CRM.Should().Be(crm);
    }

    [Test]
    public void Deve_converter_um_medico_pro_out()
    {
        // Arrange
        const string nome = "Dr. Chico Science";
        const string crm = "159753/PE";
        var medico = new Medico(nome, crm);

        // Act
        var dto = medico.ToOut();

        // Assert
        dto.Id.Should().Be(medico.Id);
        dto.Nome.Should().Be(medico.Nome);
        dto.CRM.Should().Be(medico.CRM);
    }
}
