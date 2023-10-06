using Mech.Domain;
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

        estadia.HasData(new Estadia
        {
            Id = 1,
            PacienteId = 1,
            MedicoId = 1,
            QuartoId = 1,
            MotivoDaAdmissao = "Coma alcoólico / deu PT",
            DataDaAdmissao = DateTime.Now.AddDays(-1),
            DataDaAlta = DateTime.Now,
        });

        estadia.HasData(new Estadia
        {
            Id = 2,
            PacienteId = 2,
            MedicoId = 2,
            QuartoId = 3,
            MotivoDaAdmissao = "Transplante de coração",
            DataDaAdmissao = DateTime.Now.AddDays(-30),
            DataDaAlta = DateTime.Now.AddDays(-10),
        });
    }
}
