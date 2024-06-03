namespace Mech.Domain;

public class Paciente
{
    public long Id { get; set; }

    public long GeneroId { get; set; }
    public Genero Genero { get; set; }

    public long EnderecoId { get; set; }
    public Endereco Endereco { get; set; }

    public string Nome { get; set; }
    public string CPF { get; set; }
    public string CNS { get; set; }
    public DateOnly DataDeNascimento { get; set; }

    public List<Estadia> Estadias { get; set; }

    public Paciente() {}

    public Paciente(
        string nome,
        string cpf,
        string cns,
        DateOnly dataDeNascimento,
        long generoId,
        long cidadeId,
        string cep,
        string rua,
        string bairro
    ) {
        Nome = nome;
        CPF = cpf;
        CNS = cns;
        DataDeNascimento = dataDeNascimento;
        GeneroId = generoId;

        Endereco = new()
        {
            CidadeId = cidadeId,
            CEP = cep,
            Rua = rua,
            Bairro = bairro,
        };
    }
}
