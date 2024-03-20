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

        paciente.HasOne(p => p.Genero)
            .WithMany()
            .HasForeignKey(x => x.GeneroId);

        paciente.HasOne(p => p.Endereco)
            .WithMany()
            .HasForeignKey(x => x.EnderecoId);
        
        paciente.HasMany(p => p.Estadias)
            .WithOne()
            .HasForeignKey(e => e.PacienteId);

        paciente.HasData(new Paciente
        {
            Id = 1,
            GeneroId = 2,
            EnderecoId = 1,
            Cpf = "05531923023",
            CNS = "4684686781",
            Nome = "Reginaldo Rossi",
            DataDeNascimento = new DateOnly(1944, 02, 14),
        });

        paciente.HasData(new Paciente
        {
            Id = 2,
            GeneroId = 2,
            EnderecoId = 2,
            Cpf = "29328343046",
            CNS = "6186168168",
            Nome = "Faustão",
            DataDeNascimento = new DateOnly(1950, 04, 02),
        });

        paciente.HasData(new Paciente
        {
            Id = 3,
            GeneroId = 1,
            EnderecoId = 2,
            Cpf = "48993836060",
            CNS = "8451947367",
            Nome = "Raquel Dos Teclados",
            DataDeNascimento = new DateOnly(1980, 09, 18),
        });
    }
}
