using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class DepartamentoMedicoConfig : IEntityTypeConfiguration<DepartamentoMedico>
{
    public void Configure(EntityTypeBuilder<DepartamentoMedico> departamentoMedico)
    {
        departamentoMedico.ToTable("departamentos__medicos");

        departamentoMedico.HasKey(x => new { x.DepartamentoId, x.MedicoId });

        departamentoMedico.HasOne<Medico>()
            .WithMany()
            .HasForeignKey(x => x.MedicoId);

        departamentoMedico.HasOne<Departamento>()
            .WithMany()
            .HasForeignKey(x => x.DepartamentoId);
    }
}
