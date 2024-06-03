namespace Mech.Code.Dtos;

public record EstadiaIn
{
    public long PacienteId { get; set; }
    public long MedicoId { get; set; }
    public long QuartoId { get; set; }
    public string MotivoDaAdmissao { get; set; }
    public DateTime DataDaAdmissao { get; set; }
}
