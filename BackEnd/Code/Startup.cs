using Mech.Configs;
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

        services.AddCorsConfigs();

        services.AddSwaggerConfigs();
    }

    public static void Configure(IApplicationBuilder app)
    {
        app.UseCors();

        app.UseRouting();

        app.UseSwaggerThings();

        app.UseEndpoints(options => options.MapControllers());
    }
}
