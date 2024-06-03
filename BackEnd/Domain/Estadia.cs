using Mech.Code.Dtos;

namespace Mech.Domain;

public class Estadia
{
    public long Id { get; set; }
    public long PacienteId { get; set; }
    public long MedicoId { get; set; }
    public long QuartoId { get; set; }
    public string MotivoDaAdmissao { get; set; }
    public DateTime DataDaAdmissao { get; set; }
    public DateTime? DataDaAlta { get; set; }

    public Estadia() {}

    public Estadia(
        long pacienteId,
        long medicoId,
        long quartoId,
        string motivoDaAdmissao,
        DateTime dataDaAdmissao
    ) {
        PacienteId = pacienteId;
        MedicoId = medicoId;
        QuartoId = quartoId;
        MotivoDaAdmissao = motivoDaAdmissao;
        DataDaAdmissao = dataDaAdmissao;
    }

    public EstadiaOut ToOut()
    {
        return new EstadiaOut
        {
            Id = Id,
        };
    }
}
