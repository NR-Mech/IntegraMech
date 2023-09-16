namespace Mech.Domain;

public class Solicitacao
{
    public long Id { get; set; }

    public long MedicoId { get; set; }

    public long PacienteId { get; set; }

    public DateTime Data { get; set; }
}
