using Mech.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mech.Database;

public class EstadoConfig : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> estado)
    {
        estado.ToTable("estados");

        estado.HasKey(a => a.Id);

        estado.HasData(new Estado { Id = "AC", Nome = "Acre" });
        estado.HasData(new Estado { Id = "AL", Nome = "Alagoas" });
        estado.HasData(new Estado { Id = "AP", Nome = "Amapá" });
        estado.HasData(new Estado { Id = "AM", Nome = "Amazonas" });
        estado.HasData(new Estado { Id = "BA", Nome = "Bahia" });
        estado.HasData(new Estado { Id = "CE", Nome = "Ceará" });
        estado.HasData(new Estado { Id = "DF", Nome = "Distrito Federal" });
        estado.HasData(new Estado { Id = "ES", Nome = "Espirito Santo" });
        estado.HasData(new Estado { Id = "GO", Nome = "Goiás" });
        estado.HasData(new Estado { Id = "MA", Nome = "Maranhão" });
        estado.HasData(new Estado { Id = "MS", Nome = "Mato Grosso do Sul" });
        estado.HasData(new Estado { Id = "MT", Nome = "Mato Grosso" });
        estado.HasData(new Estado { Id = "MG", Nome = "Minas Gerais" });
        estado.HasData(new Estado { Id = "PA", Nome = "Pará" });
        estado.HasData(new Estado { Id = "PB", Nome = "Paraíba" });
        estado.HasData(new Estado { Id = "PR", Nome = "Paraná" });
        estado.HasData(new Estado { Id = "PE", Nome = "Pernambuco" });
        estado.HasData(new Estado { Id = "PI", Nome = "Piauí" });
        estado.HasData(new Estado { Id = "RJ", Nome = "Rio de Janeiro" });
        estado.HasData(new Estado { Id = "RN", Nome = "Rio Grande do Norte" });
        estado.HasData(new Estado { Id = "RS", Nome = "Rio Grande do Sul" });
        estado.HasData(new Estado { Id = "RO", Nome = "Rondônia" });
        estado.HasData(new Estado { Id = "RR", Nome = "Roraima" });
        estado.HasData(new Estado { Id = "SC", Nome = "Santa Catarina" });
        estado.HasData(new Estado { Id = "SP", Nome = "São Paulo" });
        estado.HasData(new Estado { Id = "SE", Nome = "Sergipe" });
        estado.HasData(new Estado { Id = "TO", Nome = "Tocantins" });
    }
}
