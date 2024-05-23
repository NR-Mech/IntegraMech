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

        especialidade.HasData(new Especialidade { Id = 1, Nome = "Alergia e Imunologia" });
        especialidade.HasData(new Especialidade { Id = 2, Nome = "Cardiologia" });
        especialidade.HasData(new Especialidade { Id = 3, Nome = "Cirurgia Oncológica" });
        especialidade.HasData(new Especialidade { Id = 4, Nome = "Geriatria" });
        especialidade.HasData(new Especialidade { Id = 5, Nome = "Homeopatia" });
    }
}
