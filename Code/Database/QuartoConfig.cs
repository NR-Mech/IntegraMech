using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class QuartoConfig : IEntityTypeConfiguration<Quarto>
{
    public void Configure(EntityTypeBuilder<Quarto> quarto)
    {
        quarto.ToTable("quartos");

        quarto.HasKey(a => a.Id);
        quarto.Property(a => a.Id).ValueGeneratedOnAdd();

        quarto.HasMany<Estadia>()
            .WithOne()
            .HasForeignKey(e => e.QuartoId);

        quarto.HasOne<TipoDeQuarto>()
            .WithMany()
            .HasForeignKey(q => q.TipoDeQuartoId);
    }
}
