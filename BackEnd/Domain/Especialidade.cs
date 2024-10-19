using Mech.Code.Dtos;

namespace Mech.Domain;

public class Especialidade
{
    public long Id { get; set; }
    public string Nome { get; set; }

    public Especialidade() { }

    public Especialidade(string nome)
    {
        Nome = nome;
    }

    public void Update(string nome)
    {
        Nome = nome;
    }

    public EspecialidadeOut ToOut()
    {
        return new()
        {
            Id = Id,
            Nome = Nome,
        };
    }
}
