using EDiaristas.Api.Servicos.Services;

namespace EDiaristas.Config.Api;

public static class ApiServicesConfig
{
    public static void RegisterApiServices(this IServiceCollection services)
    {
        services.AddScoped<IServicoService, ServicoService>();
    }
}