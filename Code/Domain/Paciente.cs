namespace Mech.Domain;

public class Paciente
{
    public long Id { get; set; }

    public long GeneroId { get; set; }
    public Genero Genero { get; set; }

    public long EnderecoId { get; set; }
    public Endereco Endereco { get; set; }

    public string Cpf { get; set; }

    public string CNS { get; set; }

    public string Nome { get; set; }

    public DateOnly DataDeNascimento { get; set; }

    public List<Estadia> Estadias { get; set; }
}
