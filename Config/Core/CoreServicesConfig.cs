using EDiaristas.Core.Services.ConsultaEndereco.Adapters;
using EDiaristas.Core.Services.ConsultaEndereco.Providers;

namespace EDiaristas.Config.Core;

public static class CoreServicesConfig
{
    public static void RegisterCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IConsultaEnderecoService, ViaCepService>();
        services.AddSingleton<HttpClient>();
    }
}