namespace Mech.Domain;

public class Triagem
{
    public long Id { get; set; }
    public string? Sexo { get; set; }
    public int? Idade { get; set; }
    public FormaDeChegada? FormaDeChegada { get; set; }
    public bool? Lesao { get; set; }
    public string? Queixa { get; set; }
    public EstadoMental? EstadoMental { get; set; }
    public bool? Dor { get; set; }
    public short? EnfDor { get; set; }
    public Disposicao? Disposicao { get; set; }
    public Classificacao? Classificacao { get; set; }
    public decimal? SBS { get; set; }
    public decimal? DBP { get; set; }
    public decimal? BC { get; set; }
    public decimal? FR { get; set; }
    public decimal? TC { get; set; }
}

public enum FormaDeChegada
{
    Caminhando,
    AmbulanciaPublica,
    AmbulanciaPrivada,
    VeiculoPrivado,
    Outro,
}

public enum EstadoMental
{
    EmAlerta,
    RespondendoVerbalmente,
    RespondendoComDor,
    SemResponder,
}

public enum Disposicao
{
    AdmitidoParaConsulta,
    AdmitidoPelaUTI,
    Liberado,
    Transferido,
    Morto,
    EmCirurgia,
}

public enum Classificacao
{
    Vermelha,
    Laranja,
    Amarelo,
    Verde,
    Azul,
}
