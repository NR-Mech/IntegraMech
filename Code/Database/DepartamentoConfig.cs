using Mech.Domain;
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
    }
}
