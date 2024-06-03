namespace Mech.Code.Dtos;

public record PacienteIn
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string CNS { get; set; }

    /// <example>05/12/2004</example>
    public string DataDeNascimento { get; set; }
    public long GeneroId { get; set; }
    public long CidadeId { get; set; }
    public string CEP { get; set; }
    public string Rua { get; set; }
    public string Bairro { get; set; }
}
