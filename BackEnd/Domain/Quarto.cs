using Mech.Code.Dtos;

namespace Mech.Domain;

public class Quarto
{
    public long Id { get; set; }
    public long TipoId { get; set; }
    public TipoDeQuarto Tipo { get; set; }

    public bool EstaOcupado { get; set; }

    public QuartoOut ToOut()
    {
        return new()
        {
            Id = Id,
            Tipo = Tipo.Nome,
            EstaOcupado = EstaOcupado,
        };
    }
}
