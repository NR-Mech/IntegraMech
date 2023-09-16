using Mech.Domain;
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
    }
}
