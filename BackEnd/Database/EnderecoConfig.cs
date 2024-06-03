using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> endereco)
    {
        endereco.ToTable("enderecos");

        endereco.HasKey(a => a.Id);
        endereco.Property(a => a.Id).ValueGeneratedOnAdd();

        endereco.Property(m => m.CEP).HasColumnName("cep");
        endereco.Property(m => m.Rua).HasColumnName("rua");
        endereco.Property(m => m.Bairro).HasColumnName("bairro");

        endereco.HasOne<Cidade>()
            .WithMany()
            .HasForeignKey(e => e.CidadeId);
    }
}
