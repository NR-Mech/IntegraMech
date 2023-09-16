using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class LaboratorioConfig : IEntityTypeConfiguration<Laboratorio>
{
    public void Configure(EntityTypeBuilder<Laboratorio> laboratorio)
    {
        laboratorio.ToTable("laboratorios");

        laboratorio.HasKey(a => a.Id);
        laboratorio.Property(a => a.Id).ValueGeneratedOnAdd();

        laboratorio.Property(m => m.Nome).HasColumnName("nome");
    }
}
