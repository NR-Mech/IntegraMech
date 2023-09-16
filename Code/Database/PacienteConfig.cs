using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class PacienteConfig : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> paciente)
    {
        paciente.ToTable("pacientes");

        paciente.HasKey(a => a.Id);
        paciente.Property(a => a.Id).ValueGeneratedOnAdd();

        paciente.Property(m => m.Cpf).HasColumnName("cpf");
        paciente.Property(m => m.CNS).HasColumnName("cns");
        paciente.Property(m => m.Nome).HasColumnName("nome");
        paciente.Property(m => m.DataDeNascimento).HasColumnName("data_de_nascimento");

        paciente.HasOne<Genero>()
            .WithMany()
            .HasForeignKey(x => x.GeneroId);

        paciente.HasOne<Endereco>()
            .WithOne()
            .HasForeignKey<Paciente>(x => x.EnderecoId);
    }
}
