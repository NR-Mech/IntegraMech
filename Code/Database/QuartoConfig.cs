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
        
        quarto.HasData(new Quarto { Id = 1, TipoDeQuartoId = 1, EstaOcupado = true });
        quarto.HasData(new Quarto { Id = 2, TipoDeQuartoId = 2, EstaOcupado = false });
        quarto.HasData(new Quarto { Id = 3, TipoDeQuartoId = 2, EstaOcupado = true });
        quarto.HasData(new Quarto { Id = 4, TipoDeQuartoId = 3, EstaOcupado = false });
    }
}
