using EDiaristas.Core.Services.ConsultaEndereco.Adapters;
using EDiaristas.Core.Services.ConsultaEndereco.Providers;
using EDiaristas.Core.Services.Token.Adapters;
using EDiaristas.Core.Services.Token.Providers;

namespace EDiaristas.Config.Core;

public static class CoreServicesConfig
{
    public static void RegisterCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IConsultaEnderecoService, ViaCepService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddSingleton<HttpClient>();
    }
}