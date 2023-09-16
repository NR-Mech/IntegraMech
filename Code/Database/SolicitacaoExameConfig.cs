using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class SolicitacaoExameConfig : IEntityTypeConfiguration<SolicitacaoExame>
{
    public void Configure(EntityTypeBuilder<SolicitacaoExame> le)
    {
        le.ToTable("solicitacoes__exames");

        le.HasKey(x => new { x.SolicitacaoId, x.ExameId });

        le.HasOne<Solicitacao>()
            .WithMany()
            .HasForeignKey(x => x.SolicitacaoId);

        le.HasOne<Exame>()
            .WithMany()
            .HasForeignKey(x => x.ExameId);
    }
}
