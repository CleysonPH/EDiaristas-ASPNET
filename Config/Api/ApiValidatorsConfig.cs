using EDiaristas.Api.Auth.Dtos;
using EDiaristas.Api.Auth.Validators;
using EDiaristas.Api.Avaliacoes.Dtos;
using EDiaristas.Api.Avaliacoes.Validators;
using EDiaristas.Api.CidadesAtentidas.Dtos;
using EDiaristas.Api.CidadesAtentidas.Validators;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Api.Diarias.Validators;
using EDiaristas.Api.EnderecosDiarista.Dtos;
using EDiaristas.Api.EnderecosDiarista.Validators;
using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Api.Usuarios.Validators;
using FluentValidation;

namespace EDiaristas.Config.Api;

public static class ApiValidatorsConfig
{
    public static void RegisterApiValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<UsuarioRequest>, UsuarioRequestValidator>();
        services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
        services.AddTransient<IValidator<RefreshTokenRequest>, RefreshTokenRequestValidator>();
        services.AddTransient<IValidator<DiariaRequest>, DiariaRequestValidator>();
        services.AddTransient<IValidator<PagamentoRequest>, PagamentoRequestValidator>();
        services.AddTransient<IValidator<EnderecoDiaristaRequest>, EnderecoDiaristaRequestValidator>();
        services.AddTransient<IValidator<CidadesAtendidasRequest>, CidadesAtendidasRequestValidator>();
        services.AddTransient<IValidator<CandidaturaData>, CandidaturaValidator>();
        services.AddTransient<IValidator<ConfirmacaoPresencaData>, ConfirmacaoPresencaValidator>();
        services.AddTransient<IValidator<AvaliacaoData>, AvaliacaoValidator>();
        services.AddTransient<IValidator<CancelamentoRequest>, CancelamentoValidator>();
        services.AddTransient<IValidator<AtualizarUsuarioRequest>, AtualizarUsuarioValidator>();
    }
}