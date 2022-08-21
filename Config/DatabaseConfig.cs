using EDiaristas.Core.Data.Contexts;

namespace EDiaristas.Config;

public static class DatabaseConfig
{
    public static void RegisterDatabase(this IServiceCollection services)
    {
        services.AddDbContext<EDiaristasDbContext>();
    }
}