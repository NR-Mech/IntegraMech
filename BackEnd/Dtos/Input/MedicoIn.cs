namespace Mech.Code.Dtos;

public record MedicoIn
{
    public string Nome { get; set; }
    public string CRM { get; set; }
    public List<long> Especialidades { get; set; } = [];
}
