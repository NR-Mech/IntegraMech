using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class EspecialidadeConfig : IEntityTypeConfiguration<Especialidade>
{
    public void Configure(EntityTypeBuilder<Especialidade> especialidade)
    {
        especialidade.ToTable("especialidades");

        especialidade.HasKey(a => a.Id);
        especialidade.Property(a => a.Id).ValueGeneratedOnAdd();

        especialidade.Property(m => m.Nome).HasColumnName("nome");
    }
}
