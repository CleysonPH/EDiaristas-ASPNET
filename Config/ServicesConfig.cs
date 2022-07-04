using EDiaristas.Config.Admin;
using EDiaristas.Config.Api;

namespace EDiaristas.Config;

public static class ServicesConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.RegisterAdminServices();
        services.RegisterApiServices();
    }
}