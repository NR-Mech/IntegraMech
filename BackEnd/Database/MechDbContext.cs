using Microsoft.EntityFrameworkCore;

namespace Mech.Database;

public class MechDbContext : DbContext
{
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Especialidade> Especialidades { get; set; }
    public DbSet<Estadia> Estadias { get; set; }
    public DbSet<Quarto> Quartos { get; set; }

    public MechDbContext(DbContextOptions<MechDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("mech");

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        SeedData(builder);
    }

    public void SeedData(ModelBuilder builder)
    {
        if (Env.IsTesting()) return;

        var cidade = builder.Entity<Cidade>();
        cidade.HasData(new Cidade { Id = 1, Nome = "Caruaru", EstadoId = "PE" });
        cidade.HasData(new Cidade { Id = 2, Nome = "Recife", EstadoId = "PE" });
        cidade.HasData(new Cidade { Id = 3, Nome = "Marília", EstadoId = "SP" });
        cidade.HasData(new Cidade { Id = 4, Nome = "Santa Cruz do Capibaribe", EstadoId = "PE" });

        var departamento = builder.Entity<Departamento>();
        departamento.HasData(new Departamento { Id = 1, Nome = "Urgência e Emergência", Descricao = "Departamento de Urgência e Emergência" });
        departamento.HasData(new Departamento { Id = 2, Nome = "Administração", Descricao = "Departamento de Administração" });
        departamento.HasData(new Departamento { Id = 3, Nome = "Recursos Humanos", Descricao = "Departamento de Recursos Humanos" });
        departamento.HasData(new Departamento { Id = 4, Nome = "Apoio Terapêutico", Descricao = "Departamento de Apoio Terapêutico" });

        var departamentoMedico = builder.Entity<DepartamentoMedico>();
        departamentoMedico.HasData(new DepartamentoMedico { DepartamentoId = 1, MedicoId = 1 });
        departamentoMedico.HasData(new DepartamentoMedico { DepartamentoId = 1, MedicoId = 2 });
        departamentoMedico.HasData(new DepartamentoMedico { DepartamentoId = 1, MedicoId = 3 });
        departamentoMedico.HasData(new DepartamentoMedico { DepartamentoId = 2, MedicoId = 2 });

        var endereco = builder.Entity<Endereco>();
        endereco.HasData(new Endereco { Id = 1, CEP = "5861618", Rua = "Paulo Afonso", Bairro = "Centenário", CidadeId = 1 });
        endereco.HasData(new Endereco { Id = 2, CEP = "6746816", Rua = "Walter de Afogados", Bairro = "Janga", CidadeId = 2 });

        var especialidade = builder.Entity<Especialidade>();
        especialidade.HasData(new Especialidade { Id = 1, Nome = "Alergia e Imunologia" });
        especialidade.HasData(new Especialidade { Id = 2, Nome = "Cardiologia" });
        especialidade.HasData(new Especialidade { Id = 3, Nome = "Cirurgia Oncológica" });
        especialidade.HasData(new Especialidade { Id = 4, Nome = "Geriatria" });
        especialidade.HasData(new Especialidade { Id = 5, Nome = "Homeopatia" });

        var estadia = builder.Entity<Estadia>();
        estadia.HasData(new Estadia
        {
            Id = 1,
            PacienteId = 1,
            MedicoId = 1,
            QuartoId = 1,
            MotivoDaAdmissao = "Coma alcoólico / deu PT",
            DataDaAdmissao = DateTime.Now.AddDays(-1),
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

        var estado = builder.Entity<Estado>();
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

        var genero = builder.Entity<Genero>();
        genero.HasData(new Genero { Id = 1, Nome = "Feminino" });
        genero.HasData(new Genero { Id = 2, Nome = "Masculino" });

        var medico = builder.Entity<Medico>();
        medico.HasData(new Medico { Id = 1, Nome = "Dr. Hans Chucrutes", CRM = "852456/SP" });
        medico.HasData(new Medico { Id = 2, Nome = "Dr. Chico Science", CRM = "159753/PE" });
        medico.HasData(new Medico { Id = 3, Nome = "Dr. Zeca Pagodinho", CRM = "354961/RJ" });

        var me = builder.Entity<MedicoEspecialidade>();
        me.HasData(new MedicoEspecialidade { MedicoId = 1, EspecialidadeId = 1 });
        me.HasData(new MedicoEspecialidade { MedicoId = 1, EspecialidadeId = 2 });
        me.HasData(new MedicoEspecialidade { MedicoId = 1, EspecialidadeId = 3 });
        me.HasData(new MedicoEspecialidade { MedicoId = 1, EspecialidadeId = 4 });
        me.HasData(new MedicoEspecialidade { MedicoId = 2, EspecialidadeId = 1 });
        me.HasData(new MedicoEspecialidade { MedicoId = 3, EspecialidadeId = 5 });

        var paciente = builder.Entity<Paciente>();
        paciente.HasData(new Paciente
        {
            Id = 1,
            GeneroId = 2,
            EnderecoId = 1,
            CPF = "05531923023",
            CNS = "4684686781",
            Nome = "Reginaldo Rossi",
            DataDeNascimento = new DateOnly(1944, 02, 14),
        });
        paciente.HasData(new Paciente
        {
            Id = 2,
            GeneroId = 2,
            EnderecoId = 2,
            CPF = "29328343046",
            CNS = "6186168168",
            Nome = "Faustão",
            DataDeNascimento = new DateOnly(1950, 04, 02),
        });
        paciente.HasData(new Paciente
        {
            Id = 3,
            GeneroId = 1,
            EnderecoId = 2,
            CPF = "48993836060",
            CNS = "8451947367",
            Nome = "Raquel Dos Teclados",
            DataDeNascimento = new DateOnly(1980, 09, 18),
        });

        var quarto = builder.Entity<Quarto>();
        quarto.HasData(new Quarto { Id = 1, TipoId = 1, EstaOcupado = true });
        quarto.HasData(new Quarto { Id = 2, TipoId = 2, EstaOcupado = false });
        quarto.HasData(new Quarto { Id = 3, TipoId = 2, EstaOcupado = true });
        quarto.HasData(new Quarto { Id = 4, TipoId = 3, EstaOcupado = false });

        var tipoDeQuarto = builder.Entity<TipoDeQuarto>();
        tipoDeQuarto.HasData(new TipoDeQuarto { Id = 1, Nome = "UTI" });
        tipoDeQuarto.HasData(new TipoDeQuarto { Id = 2, Nome = "Leito Clínico" });
        tipoDeQuarto.HasData(new TipoDeQuarto { Id = 3, Nome = "Leito Cirúrgico" });
    }

    public async Task ResetDbAsync()
    {
        if (Env.IsTesting())
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();
        }
    }

    public void MigrateDb()
    {
        if (!Env.IsTesting())
        {
            Database.Migrate();
        }
    }
}
