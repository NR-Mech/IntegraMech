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

        cidade.HasOne(x => x.Estado)
            .WithMany()
            .HasForeignKey(c => c.EstadoId);
    }
}
