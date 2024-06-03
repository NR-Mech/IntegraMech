using Mech.Code.Dtos;

namespace Mech.Domain;

public class Genero
{
    public long Id { get; set; }
    public string Nome { get; set; }

    public Genero() { }

    public Genero(string nome)
    {
        Nome = nome;
    }

    public GeneroOut ToOut()
    {
        return new GeneroOut
        {
            Id = Id,
            Nome = Nome,
        };
    }
}
