using EDiaristas.Api.Avaliacoes.Mappers;
using EDiaristas.Api.CidadesAtentidas.Mappers;
using EDiaristas.Api.Diarias.Mappers;
using EDiaristas.Api.Diaristas.Mappers;
using EDiaristas.Api.EnderecosDiarista.Mappers;
using EDiaristas.Api.Me.Mappers;
using EDiaristas.Api.Oportunidades.Mappers;
using EDiaristas.Api.Servicos.Mappers;
using EDiaristas.Api.Usuarios.Mappers;

namespace EDiaristas.Config.Api;

public static class ApiMappersConfig
{
    public static void RegisterApiMappers(this IServiceCollection services)
    {
        services.AddScoped<IServicoMapper, ServicoMapper>();
        services.AddScoped<IDiaristaMapper, DiaristaMapper>();
        services.AddScoped<IUsuarioMapper, UsuarioMapper>();
        services.AddScoped<IMeMapper, MeMapper>();
        services.AddScoped<IDiariaMapper, DiariaMapper>();
        services.AddScoped<IEnderecoDiaristaMapper, EnderecoDiaristaMapper>();
        services.AddScoped<ICidadeAtendidaMapper, CidadeAtendidaMapper>();
        services.AddScoped<IOportunidadeMapper, OportunidadeMapper>();
        services.AddScoped<IAvaliacaoMapper, AvaliacaoMapper>();
    }
}