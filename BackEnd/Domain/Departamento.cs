using Mech.Code.Dtos;

namespace Mech.Domain;

public class Departamento
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public Departamento() { }

    public Departamento(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }

    public DepartamentoOut ToOut()
    {
        return new DepartamentoOut
        {
            Id = Id,
            Nome = Nome,
            Descricao = Descricao,
        };
    }
}
