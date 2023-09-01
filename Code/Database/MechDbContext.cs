using Microsoft.EntityFrameworkCore;

namespace Mech.Database;

public class MechDbContext : DbContext
{
    public MechDbContext(DbContextOptions<MechDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("mech");

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
