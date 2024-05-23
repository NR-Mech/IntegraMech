using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class CidadeConfig : IEntityTypeConfiguration<Cidade>
{
    public void Configure(EntityTypeBuilder<Cidade> cidade)
    {
        cidade.ToTable("cidades");

        cidade.HasKey(a => a.Id);
        cidade.Property(a => a.Id).ValueGeneratedOnAdd();

        cidade.HasOne<Estado>()
            .WithMany()
            .HasForeignKey(c => c.EstadoId);

        if (Env.IsTesting()) return;
        cidade.HasData(new Cidade { Id = 1, Nome = "Caruaru", EstadoId = "PE" });
        cidade.HasData(new Cidade { Id = 2, Nome = "Recife", EstadoId = "PE" });
        cidade.HasData(new Cidade { Id = 3, Nome = "Marília", EstadoId = "SP" });
    }
}
