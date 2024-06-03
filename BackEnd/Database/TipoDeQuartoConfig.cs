using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class TipoDeQuartoConfig : IEntityTypeConfiguration<TipoDeQuarto>
{
    public void Configure(EntityTypeBuilder<TipoDeQuarto> quarto)
    {
        quarto.ToTable("tipos_de_quarto");

        quarto.HasKey(a => a.Id);
        quarto.Property(a => a.Id).ValueGeneratedOnAdd();
    }
}
