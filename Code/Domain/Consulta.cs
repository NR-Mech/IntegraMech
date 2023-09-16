namespace Mech.Domain;

public class Consulta
{
    public long Id { get; set; }

    public long MedicoId { get; set; }

    public long PacienteId { get; set; }

    public DateTime Data { get; set; }
}
