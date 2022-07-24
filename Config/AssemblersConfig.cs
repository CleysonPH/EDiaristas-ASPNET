using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Diarias.Assemblers;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Api.Home.Assemblers;
using EDiaristas.Api.Home.Dtos;

namespace EDiaristas.Config;

public static class AssemblersConfig
{
    public static void RegisterAssemblers(this IServiceCollection services)
    {
        services.AddScoped<IAssembler<HomeResponse>, HomeAssembler>();
        services.AddScoped<IAssembler<UsuarioResponse>, UsuarioResponseAssembler>();
        services.AddScoped<IAssembler<DiariaResponse>, DiariaResponseAssembler>();
    }
}