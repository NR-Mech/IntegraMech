namespace Mech.Domain;

public class Medico
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string CRM { get; set; }

    public Medico() { }

    public Medico(string nome, string crm)
    {
        Nome = nome;
        CRM = crm;
    }
}
