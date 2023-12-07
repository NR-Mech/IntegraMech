using Mech.Settings;
using Mech.Database;
using Microsoft.EntityFrameworkCore;

namespace Mech.Configs;

public static class EfCoreConfigs
{
    public static void AddEfCoreConfigs(this IServiceCollection services)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var db = services.BuildServiceProvider().GetService<DatabaseSettings>()!;

        services.AddDbContext<MechDbContext>(options =>
        {
            options.UseNpgsql(db.ConnectionString);
            options.UseSnakeCaseNamingConvention();
        });
    }
}
