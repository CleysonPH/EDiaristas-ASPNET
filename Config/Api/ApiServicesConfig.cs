using EDiaristas.Api.Auth.Services;
using EDiaristas.Api.Avaliacoes.Services;
using EDiaristas.Api.CidadesAtentidas.Services;
using EDiaristas.Api.Diarias.Services;
using EDiaristas.Api.Diaristas.Services;
using EDiaristas.Api.EnderecosDiarista.Services;
using EDiaristas.Api.Me.Services;
using EDiaristas.Api.Oportunidades.Services;
using EDiaristas.Api.Pagamentos.Services;
using EDiaristas.Api.ResetSenha.Services;
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
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMeService, MeService>();
        services.AddScoped<IDiariaService, DiariaService>();
        services.AddScoped<IEnderecoDiaristaService, EnderecoDiaristaService>();
        services.AddScoped<ICidadeAtendidaService, CidadeAtendidaService>();
        services.AddScoped<IOportunidadeService, OportunidadeService>();
        services.AddScoped<ICandidaturaService, CandidaturaService>();
        services.AddScoped<IConfirmacaoPresencaService, ConfirmacaoPresencaService>();
        services.AddScoped<IAvaliacaoService, AvaliacaoService>();
        services.AddScoped<ICancelamentoService, CancelamentoService>();
        services.AddScoped<IPagamentoService, PagamentoService>();
        services.AddScoped<IFotoUsuarioService, FotoUsuarioService>();
        services.AddScoped<IResetSenhaService, ResetSenhaService>();
    }
}