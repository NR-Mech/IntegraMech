using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class GeneroConfig : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> genero)
    {
        genero.ToTable("generos");

        genero.HasKey(a => a.Id);
        genero.Property(a => a.Id).ValueGeneratedOnAdd();

        genero.Property(m => m.Nome).HasColumnName("nome");

        genero.HasData(new Genero { Id = 1, Nome = "Feminino" });
        genero.HasData(new Genero { Id = 2, Nome = "Masculino" });
    }
}
