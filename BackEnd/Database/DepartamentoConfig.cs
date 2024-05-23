using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class DepartamentoConfig : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> departamento)
    {
        departamento.ToTable("departamentos");

        departamento.HasKey(a => a.Id);
        departamento.Property(a => a.Id).ValueGeneratedOnAdd();

        if (Env.IsTesting()) return;
        departamento.HasData(new Departamento { Id = 1, Nome = "Urgência e Emergência", Descricao = "Departamento de Urgência e Emergência" });
        departamento.HasData(new Departamento { Id = 2, Nome = "Administração", Descricao = "Departamento de Administração" });
        departamento.HasData(new Departamento { Id = 3, Nome = "Recursos Humanos", Descricao = "Departamento de Recursos Humanos" });
        departamento.HasData(new Departamento { Id = 4, Nome = "Apoio Terapêutico", Descricao = "Departamento de Apoio Terapêutico" });
    }
}
