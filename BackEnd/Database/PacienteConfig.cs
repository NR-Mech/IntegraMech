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

        paciente.Property(m => m.CPF).HasColumnName("cpf");
        paciente.Property(m => m.CNS).HasColumnName("cns");
        paciente.Property(m => m.Nome).HasColumnName("nome");
        paciente.Property(m => m.DataDeNascimento).HasColumnName("data_de_nascimento");

        paciente.HasOne(p => p.Genero)
            .WithMany()
            .HasForeignKey(x => x.GeneroId);

        paciente.HasOne(p => p.Endereco)
            .WithMany()
            .HasForeignKey(x => x.EnderecoId);
        
        paciente.HasMany(p => p.Estadias)
            .WithOne()
            .HasForeignKey(e => e.PacienteId);
    }
}
