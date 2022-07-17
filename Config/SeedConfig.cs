using EDiaristas.Core.Data.Seeds;

namespace EDiaristas.Config;

public static class SeedConfig
{
    public static void RegisterSeeds(this IServiceCollection services)
    {
        services.AddScoped<ISeedUsuarios, SeedUsuarios>();
    }

    public static void ExecuteSeeds(this WebApplication app)
    {
        var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
        using (var scope = scopedFactory?.CreateScope())
        {
            scope?.ServiceProvider?.GetService<ISeedUsuarios>()?.Seed();
        }
    }
}