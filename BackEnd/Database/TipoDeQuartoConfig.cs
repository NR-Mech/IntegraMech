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

        if (Env.IsTesting()) return;
        quarto.HasData(new TipoDeQuarto { Id = 1, Nome = "UTI" });
        quarto.HasData(new TipoDeQuarto { Id = 2, Nome = "Leito Clínico" });
        quarto.HasData(new TipoDeQuarto { Id = 3, Nome = "Leito Cirúrgico" });
    }
}
