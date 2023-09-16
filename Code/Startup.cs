using Syki.Mech;
using Mech.Database;
using Mech.Settings;

namespace Mech;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddSingleton<DatabaseSettings>();

        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddEfCoreConfigs();
    }

    public static void Configure(IApplicationBuilder app, MechDbContext ctx)
    {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();

        app.UseRouting();

        app.UseEndpoints(options => options.MapControllers());
    }
}
