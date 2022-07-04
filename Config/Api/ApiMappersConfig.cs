using EDiaristas.Api.Servicos.Mappers;

namespace EDiaristas.Config.Api;

public static class ApiMappersConfig
{
    public static void RegisterApiMappers(this IServiceCollection services)
    {
        services.AddScoped<IServicoMapper, ServicoMapper>();
    }
}