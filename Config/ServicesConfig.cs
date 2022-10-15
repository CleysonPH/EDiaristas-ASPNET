using EDiaristas.Config.Admin;
using EDiaristas.Config.Api;
using EDiaristas.Config.Core;

namespace EDiaristas.Config;

public static class ServicesConfig
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterApiServices();
        services.RegisterCoreServices(configuration);
        services.RegisterAdminServices();

    }
}