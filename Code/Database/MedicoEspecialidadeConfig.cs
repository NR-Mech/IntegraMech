using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class MedicoEspecialidadeConfig : IEntityTypeConfiguration<MedicoEspecialidade>
{
    public void Configure(EntityTypeBuilder<MedicoEspecialidade> me)
    {
        me.ToTable("medicos__especialidades");

        me.HasKey(x => new { x.MedicoId, x.EspecialidadeId });

        me.HasOne<Medico>()
            .WithMany()
            .HasForeignKey(x => x.MedicoId);

        me.HasOne<Especialidade>()
            .WithMany()
            .HasForeignKey(x => x.EspecialidadeId);
    }
}
