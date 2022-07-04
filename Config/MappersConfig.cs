using EDiaristas.Config.Admin;
using EDiaristas.Config.Api;

namespace EDiaristas.Config;

public static class MappersConfig
{
    public static void RegisterMappers(this IServiceCollection services)
    {
        services.RegisterAdminMappers();
        services.RegisterApiMappers();
    }
}