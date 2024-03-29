using EDiaristas.Core.Repositories.Avaliacoes;
using EDiaristas.Core.Repositories.CidadesAtendidas;
using EDiaristas.Core.Repositories.Diarias;
using EDiaristas.Core.Repositories.InvalidatedTokens;
using EDiaristas.Core.Repositories.Pagamentos;
using EDiaristas.Core.Repositories.PasswordRestToken;
using EDiaristas.Core.Repositories.Servicos;
using EDiaristas.Core.Repositories.Usuarios;

namespace EDiaristas.Config;

public static class RepositoriesConfig
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IServicoRepository, ServicoRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IInvalidatedTokenRepository, InvalidatedTokenRepository>();
        services.AddScoped<IDiariaRepository, DiariaRepository>();
        services.AddScoped<ICidadeAtendidaRepository, CidadeAtendidaRepository>();
        services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
        services.AddScoped<IPagamentoRepository, PagamentoRepository>();
        services.AddScoped<IPasswordResetTokenRepository, PasswordResetTokenRepository>();
    }
}