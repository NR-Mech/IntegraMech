namespace Mech.Domain;

public class MedicoEspecialidade
{
    public long MedicoId { get; set; }
    public long EspecialidadeId { get; set; }

    public MedicoEspecialidade() {}

    public MedicoEspecialidade(long medicoId, long especialidadeId)
    {
        MedicoId = medicoId;
        EspecialidadeId = especialidadeId;
    }
}
