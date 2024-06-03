using Mech.Code.Dtos;

namespace Mech.Domain;

public class Cidade
{
    public long Id { get; set; }

    public string EstadoId { get; set; }
    public Estado Estado { get; set; }

    public string Nome { get; set; }

    public CidadeOut ToOut()
    {
        return new CidadeOut
        {
            Id = Id,
            Nome = Nome,
            Estado = Estado.Nome,
        };
    }
}
