namespace Mech.Domain;

public class Estadia
{
    public long Id { get; set; }

    public long PacienteId { get; set; }

    public long MedicoId { get; set; }

    public long QuartoId { get; set; }

    public string MotivoDaAdmissao { get; set; }

    public DateTime DataDaAdmissao { get; set; }

    public DateTime DataDaAlta { get; set; }
}
