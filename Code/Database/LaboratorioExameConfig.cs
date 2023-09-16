using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class LaboratorioExameConfig : IEntityTypeConfiguration<LaboratorioExame>
{
    public void Configure(EntityTypeBuilder<LaboratorioExame> le)
    {
        le.ToTable("laboratorios__exames");

        le.HasKey(x => new { x.LaboratorioId, x.ExameId });

        le.HasOne<Laboratorio>()
            .WithMany()
            .HasForeignKey(x => x.LaboratorioId);

        le.HasOne<Exame>()
            .WithMany()
            .HasForeignKey(x => x.ExameId);
    }
}
