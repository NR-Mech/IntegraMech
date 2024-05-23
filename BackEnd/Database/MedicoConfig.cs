using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class MedicoConfig : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> medico)
    {
        medico.ToTable("medicos");

        medico.HasKey(a => a.Id);
        medico.Property(a => a.Id).ValueGeneratedOnAdd();

        medico.Property(m => m.Nome).HasColumnName("nome");
        medico.Property(m => m.CRM).HasColumnName("crm");

        medico.HasMany<Estadia>()
            .WithOne()
            .HasForeignKey(e => e.MedicoId);
        
        if (Env.IsTesting()) return;
        medico.HasData(new Medico { Id = 1, Nome = "Dr. Hans Chucrutes", CRM = "852456/SP" });
        medico.HasData(new Medico { Id = 2, Nome = "Dr. Chico Science", CRM = "159753/PE" });
        medico.HasData(new Medico { Id = 3, Nome = "Dr. Zeca Pagodinho", CRM = "354961/RJ" });
    }
}
