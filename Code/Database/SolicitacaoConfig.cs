using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class SolicitacaoConfig : IEntityTypeConfiguration<Solicitacao>
{
    public void Configure(EntityTypeBuilder<Solicitacao> solicitacao)
    {
        solicitacao.ToTable("solicitacoes");

        solicitacao.HasKey(a => a.Id);
        solicitacao.Property(a => a.Id).ValueGeneratedOnAdd();

        solicitacao.HasOne<Medico>()
            .WithMany()
            .HasForeignKey(x => x.MedicoId);

        solicitacao.HasOne<Paciente>()
            .WithMany()
            .HasForeignKey(x => x.PacienteId);

        solicitacao.Property(x => x.Data).HasColumnName("data");
    }
}
