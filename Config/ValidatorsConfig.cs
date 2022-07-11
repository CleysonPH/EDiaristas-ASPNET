using EDiaristas.Config.Admin;
using EDiaristas.Config.Api;

namespace EDiaristas.Config;

public static class ValidatorsConfig
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.RegisterAdminValidators();
        services.RegisterApiValidators();
    }
}