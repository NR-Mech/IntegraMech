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
        
        if (Env.IsTesting()) return;
        me.HasData(new MedicoEspecialidade { MedicoId = 1, EspecialidadeId = 1 });
        me.HasData(new MedicoEspecialidade { MedicoId = 1, EspecialidadeId = 2 });
        me.HasData(new MedicoEspecialidade { MedicoId = 1, EspecialidadeId = 3 });
        me.HasData(new MedicoEspecialidade { MedicoId = 1, EspecialidadeId = 4 });
        me.HasData(new MedicoEspecialidade { MedicoId = 2, EspecialidadeId = 1 });
        me.HasData(new MedicoEspecialidade { MedicoId = 3, EspecialidadeId = 5 });
    }
}
