using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class TriagemConfig : IEntityTypeConfiguration<Triagem>
{
    public void Configure(EntityTypeBuilder<Triagem> triagem)
    {
        triagem.ToTable("triagens");

        triagem.HasKey(a => a.Id);
        triagem.Property(a => a.Id).ValueGeneratedOnAdd();
    }
}
