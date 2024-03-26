
namespace Mech.Code.Dtos;


public class PacienteOut
{
    public long Id { get; set; }
    public string Cpf { get; set; }
    public string CNS { get; set; }
    public string Nome { get; set; }
    public DateOnly DataDeNascimento { get; set; }
    public string Genero { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string CEP { get; set; }
    public string Rua { get; set; }
    public string Bairro { get; set; }
}
