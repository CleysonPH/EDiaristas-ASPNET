using EDiaristas.Api.Diaristas.Services;
using EDiaristas.Api.Servicos.Services;
using EDiaristas.Api.Usuarios.Services;

namespace EDiaristas.Config.Api;

public static class ApiServicesConfig
{
    public static void RegisterApiServices(this IServiceCollection services)
    {
        services.AddScoped<IServicoService, ServicoService>();
        services.AddScoped<IDiaristaService, DiaristaService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
    }
}