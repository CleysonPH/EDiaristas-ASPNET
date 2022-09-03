using EDiaristas.Admin.Auth.Services;
using EDiaristas.Admin.Diarias.Services;
using EDiaristas.Admin.Servicos.Services;
using EDiaristas.Admin.Usuarios.Services;

namespace EDiaristas.Config.Admin;

public static class AdminServicesConfig
{
    public static void RegisterAdminServices(this IServiceCollection services)
    {
        services.AddScoped<IServicoService, ServicoService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IDiariaService, DiariaService>();
    }
}