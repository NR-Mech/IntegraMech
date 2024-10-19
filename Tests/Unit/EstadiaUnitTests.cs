using Mech.Domain;

namespace Mech.Tests.Unit;

public class EstadiaUnitTests
{
    [Test]
    public void Deve_criar_uma_estadia()
    {
        // Arrange
        const long pacienteId = 1;
        const long medicoId = 2;
        const long quartoId = 3;
        const string motivoDaAdmissao = "Coma alcoólico / deu PT";
        var dataDaAdmissao = DateTime.Now.AddDays(-1);

        // Act
        var estadia = new Estadia(pacienteId, medicoId, quartoId, motivoDaAdmissao, dataDaAdmissao);

        // Assert
        estadia.PacienteId.Should().Be(pacienteId);
        estadia.MedicoId.Should().Be(medicoId);
        estadia.QuartoId.Should().Be(quartoId);
        estadia.MotivoDaAdmissao.Should().Be(motivoDaAdmissao);
        estadia.DataDaAdmissao.Should().BeCloseTo(dataDaAdmissao, TimeSpan.FromSeconds(5));
    }

    [Test]
    public void Deve_converter_uma_estadia_pro_out()
    {
        // Arrange
        const long pacienteId = 1;
        const long medicoId = 2;
        const long quartoId = 3;
        const string motivoDaAdmissao = "Coma alcoólico / deu PT";
        var dataDaAdmissao = DateTime.Now.AddDays(-1);

        var estadia = new Estadia(pacienteId, medicoId, quartoId, motivoDaAdmissao, dataDaAdmissao);

        // Act
        var dto = estadia.ToOut();

        // Assert
        dto.Id.Should().Be(estadia.Id);
    }
}
