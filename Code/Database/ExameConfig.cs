using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class ExameConfig : IEntityTypeConfiguration<Exame>
{
    public void Configure(EntityTypeBuilder<Exame> exame)
    {
        exame.ToTable("exames");

        exame.HasKey(a => a.Id);
        exame.Property(a => a.Id).ValueGeneratedOnAdd();

        exame.Property(m => m.Nome).HasColumnName("nome");
    }
}
