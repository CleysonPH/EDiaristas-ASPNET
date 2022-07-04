using EDiaristas.Admin.Servicos.Mappers;
using EDiaristas.Admin.Usuarios.Mappers;

namespace EDiaristas.Config.Admin;

public static class AdminMappersConfig
{
    public static void RegisterAdminMappers(this IServiceCollection services)
    {
        services.AddScoped<IServicoMapper, ServicoMapper>();
        services.AddScoped<IUsuarioMapper, UsuarioMapper>();
    }
}