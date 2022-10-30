using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.Authentication.Providers;
using EDiaristas.Core.Services.ConsultaCidade.Adapters;
using EDiaristas.Core.Services.ConsultaCidade.Providers.Ibge;
using EDiaristas.Core.Services.ConsultaDistancia.Adapters;
using EDiaristas.Core.Services.ConsultaDistancia.Providers.GoogleMatrix;
using EDiaristas.Core.Services.ConsultaEndereco.Adapters;
using EDiaristas.Core.Services.ConsultaEndereco.Providers;
using EDiaristas.Core.Services.DiaristaIndice.Adapters;
using EDiaristas.Core.Services.DiaristaIndice.Providers;
using EDiaristas.Core.Services.Email;
using EDiaristas.Core.Services.Email.Smtp;
using EDiaristas.Core.Services.GatewayPagamento;
using EDiaristas.Core.Services.GatewayPagamento.PagarMe;
using EDiaristas.Core.Services.PasswordEnconder.Adapters;
using EDiaristas.Core.Services.PasswordEnconder.Providers;
using EDiaristas.Core.Services.PasswordReset.Adapters;
using EDiaristas.Core.Services.PasswordReset.Providers;
using EDiaristas.Core.Services.Storage.Adapters;
using EDiaristas.Core.Services.Storage.Providers;
using EDiaristas.Core.Services.Storage.Providers.Local;
using EDiaristas.Core.Services.Storage.Providers.S3;
using EDiaristas.Core.Services.Token.Adapters;
using EDiaristas.Core.Services.Token.Providers;

namespace EDiaristas.Config.Core;

public static class CoreServicesConfig
{
    public static void RegisterCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IConsultaEnderecoService, ViaCepService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordEnconderService, BCryptService>();
        services.AddScoped<ICustomAuthenticationService, CustomAuthenticationService>();
        services.AddScoped<IConsultaCidadeService, IbgeConsultaCidadeService>();
        services.AddScoped<IConsultaDistanciaService, GoogleMatrixService>();
        services.AddScoped<IDiaristaIndiceService, DiaristaIndiceService>();
        services.AddScoped<IGatewayPagamentoService, PagarMeService>();
        services.AddScoped<IEmailService, SmtpEmailService>();
        services.AddScoped<IPasswordResetService, PasswordResetService>();

        var storageProvider = configuration.GetValue<StorageProviderOptions>("Storage:Provider");
        switch (storageProvider)
        {
            case StorageProviderOptions.Local:
                services.AddScoped<IStorageService, LocalStorageService>();
                break;
            case StorageProviderOptions.S3:
                services.AddScoped<IStorageService, S3StorageService>();
                break;
            default:
                throw new Exception("Storage provider not found");
        };

        services.AddSingleton<HttpClient>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}