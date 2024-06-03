using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class EstadiaConfig : IEntityTypeConfiguration<Estadia>
{
    public void Configure(EntityTypeBuilder<Estadia> estadia)
    {
        estadia.ToTable("estadias");

        estadia.HasKey(a => a.Id);
        estadia.Property(a => a.Id).ValueGeneratedOnAdd();
    }
}
