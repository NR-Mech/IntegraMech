using Microsoft.EntityFrameworkCore;

namespace Mech.Database;

public class MechDbContext : DbContext
{
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }

    public DbSet<Especialidade> Especialidades { get; set; }
    public MechDbContext(DbContextOptions<MechDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("mech");

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
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
