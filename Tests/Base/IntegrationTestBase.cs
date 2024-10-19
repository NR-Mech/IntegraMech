using Mech.Domain;
using Mech.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Mech.Tests.Base;

public class IntegrationTestBase
{
    protected BackWebApplicationFactory _factory = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        _factory = new BackWebApplicationFactory();
        using var scope = _factory.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MechDbContext>();

        await ctx.ResetDbAsync();
        await SeedEstados();
        await SeedCidades();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _factory.DisposeAsync();
    }

    public MechDbContext GetDbContext()
    {
        var scope = _factory.Services.CreateScope();
        return scope.ServiceProvider.GetRequiredService<MechDbContext>();
    }

    protected async Task SeedEstados()
    {
        var ctx = GetDbContext();

        ctx.Add(new Estado { Id = "AC", Nome = "Acre" });
        ctx.Add(new Estado { Id = "AL", Nome = "Alagoas" });
        ctx.Add(new Estado { Id = "AP", Nome = "Amapá" });
        ctx.Add(new Estado { Id = "AM", Nome = "Amazonas" });
        ctx.Add(new Estado { Id = "BA", Nome = "Bahia" });
        ctx.Add(new Estado { Id = "CE", Nome = "Ceará" });
        ctx.Add(new Estado { Id = "DF", Nome = "Distrito Federal" });
        ctx.Add(new Estado { Id = "ES", Nome = "Espirito Santo" });
        ctx.Add(new Estado { Id = "GO", Nome = "Goiás" });
        ctx.Add(new Estado { Id = "MA", Nome = "Maranhão" });
        ctx.Add(new Estado { Id = "MS", Nome = "Mato Grosso do Sul" });
        ctx.Add(new Estado { Id = "MT", Nome = "Mato Grosso" });
        ctx.Add(new Estado { Id = "MG", Nome = "Minas Gerais" });
        ctx.Add(new Estado { Id = "PA", Nome = "Pará" });
        ctx.Add(new Estado { Id = "PB", Nome = "Paraíba" });
        ctx.Add(new Estado { Id = "PR", Nome = "Paraná" });
        ctx.Add(new Estado { Id = "PE", Nome = "Pernambuco" });
        ctx.Add(new Estado { Id = "PI", Nome = "Piauí" });
        ctx.Add(new Estado { Id = "RJ", Nome = "Rio de Janeiro" });
        ctx.Add(new Estado { Id = "RN", Nome = "Rio Grande do Norte" });
        ctx.Add(new Estado { Id = "RS", Nome = "Rio Grande do Sul" });
        ctx.Add(new Estado { Id = "RO", Nome = "Rondônia" });
        ctx.Add(new Estado { Id = "RR", Nome = "Roraima" });
        ctx.Add(new Estado { Id = "SC", Nome = "Santa Catarina" });
        ctx.Add(new Estado { Id = "SP", Nome = "São Paulo" });
        ctx.Add(new Estado { Id = "SE", Nome = "Sergipe" });
        ctx.Add(new Estado { Id = "TO", Nome = "Tocantins" });

        await ctx.SaveChangesAsync();
    }

    protected async Task SeedCidades()
    {
        var ctx = GetDbContext();

        ctx.Add(new Cidade { Id = 1, Nome = "Caruaru", EstadoId = "PE" });
        ctx.Add(new Cidade { Id = 2, Nome = "Recife", EstadoId = "PE" });
        ctx.Add(new Cidade { Id = 3, Nome = "Marília", EstadoId = "SP" });
        ctx.Add(new Cidade { Id = 4, Nome = "Santa Cruz do Capibaribe", EstadoId = "PE" });

        await ctx.SaveChangesAsync();
    }

    protected async Task SeedQuartos()
    {
        var ctx = GetDbContext();

        ctx.Add(new TipoDeQuarto { Nome = "UTI" });
        ctx.Add(new TipoDeQuarto { Nome = "Leito Clínico" });
        ctx.Add(new TipoDeQuarto { Nome = "Leito Cirúrgico" });

        await ctx.SaveChangesAsync();

        ctx.Add(new Quarto { TipoId = 1, EstaOcupado = false });
        ctx.Add(new Quarto { TipoId = 2, EstaOcupado = false });
        ctx.Add(new Quarto { TipoId = 3, EstaOcupado = false });

        await ctx.SaveChangesAsync();
    }

    protected async Task SeedGeneros()
    {
        var ctx = GetDbContext();

        ctx.Add(new Genero { Nome = "Feminino" });
        ctx.Add(new Genero { Nome = "Masculino" });

        await ctx.SaveChangesAsync();
    }
}
