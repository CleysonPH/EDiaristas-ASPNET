using EDiaristas.Core.Permissions;

namespace EDiaristas.Config;

public static class PermissionsConfig
{
    public static void RegisterPermissions(this IServiceCollection services)
    {
        services.AddScoped<DiariaPermissions>();
    }
}