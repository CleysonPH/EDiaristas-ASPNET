using EDiaristas.Core.Repositories.Servicos;
using EDiaristas.Core.Repositories.Usuarios;

namespace EDiaristas.Config;

public static class RepositoriesConfig
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IServicoRepository, ServicoRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
}