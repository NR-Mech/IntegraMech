namespace Mech.Code.Dtos;

public record QuartoOut
{
    public long Id { get; set; }
    public string Tipo { get; set; }
    public bool EstaOcupado { get; set; }
}
