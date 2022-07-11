using EDiaristas.Api.Common.NamingPolicies;

namespace EDiaristas.Config;

public static class ControllersConfig
{
    public static void RegisterControllers(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance);
    }
}