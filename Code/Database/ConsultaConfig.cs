using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class ConsultaConfig : IEntityTypeConfiguration<Consulta>
{
    public void Configure(EntityTypeBuilder<Consulta> consulta)
    {
        consulta.ToTable("consultas");

        consulta.HasKey(a => a.Id);
        consulta.Property(a => a.Id).ValueGeneratedOnAdd();

        consulta.HasOne<Medico>()
            .WithMany()
            .HasForeignKey(x => x.MedicoId);

        consulta.HasOne<Paciente>()
            .WithMany()
            .HasForeignKey(x => x.PacienteId);

        consulta.Property(x => x.Data).HasColumnName("data");
    }
}
