
namespace Mech.Code.Dtos;

public class EstadiaOut
{
    public long Id { get; set; }
    public string Paciente { get; set; }
    public string Medico { get; set; }
    public string Quarto { get; set; }
    public string MotivoDaAdmissao { get; set; }
    public DateTime DataDaAdmissao { get;set;}
    public DateTime? DataDaAlta { get; set; }
}