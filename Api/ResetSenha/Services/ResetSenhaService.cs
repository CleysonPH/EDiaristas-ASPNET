using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.ResetSenha.Dtos;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Services.Email;
using EDiaristas.Core.Services.PasswordReset.Adapters;
using FluentValidation;

namespace EDiaristas.Api.ResetSenha.Services;

public class ResetSenhaService : IResetSenhaService
{
    private readonly String _frontEndUrl;
    private readonly IEmailService _emailService;
    private readonly IPasswordResetService _passwordResetService;
    private readonly IValidator<ConfirmaResetSenhaRequest> _confirmaResetSenhaValidator;
    private readonly IValidator<SolicitarResetSenhaRequest> _solicitarResetSenhaValidator;

    public ResetSenhaService(
        IEmailService emailService,
        IConfiguration configuration,
        IPasswordResetService passwordResetService,
        IValidator<ConfirmaResetSenhaRequest> confirmaResetSenhaValidator,
        IValidator<SolicitarResetSenhaRequest> solicitarResetSenhaValidator)
    {
        var frontendHost = configuration.GetValue<string>("Frontend:Host");
        var frontendResetPasswordPath = configuration.GetValue<string>("Frontend:ResetPasswordPath");
        _frontEndUrl = $"{frontendHost}{frontendResetPasswordPath}";

        _emailService = emailService;
        _passwordResetService = passwordResetService;
        _confirmaResetSenhaValidator = confirmaResetSenhaValidator;
        _solicitarResetSenhaValidator = solicitarResetSenhaValidator;
    }

    public MessageResponse SolicitarResetSenha(SolicitarResetSenhaRequest request)
    {
        try
        {
            trySolicitarResetSenha(request);
        }
        catch (UsuarioNotFoundException)
        {
            // Não faz nada, pois não queremos dar pistas para invasores
        }
        return new MessageResponse("Um link para redefinir sua senha foi enviado para o seu e-mail.");
    }

    public MessageResponse ConfirmaResetSenha(ConfirmaResetSenhaRequest request)
    {
        _confirmaResetSenhaValidator.ValidateAndThrow(request);
        _passwordResetService.ResetarSenha(request.Token, request.Password);
        return new MessageResponse("Senha redefinida com sucesso.");
    }

    private void trySolicitarResetSenha(SolicitarResetSenhaRequest request)
    {
        _solicitarResetSenhaValidator.ValidateAndThrow(request);
        var passwordResetToken = _passwordResetService.CriarPasswordResetToken(request.Email);
        var passwordResetUrl = $"{_frontEndUrl}?token={passwordResetToken}";
        var emailParams = new EmailParams(
            assunto: "Solicitação de redefinição de senha",
            destinatario: request.Email,
            props: new Dictionary<string, string>
            {
                { "Link", passwordResetUrl }
            },
            template: EmailParams.TemplateOptions.ResetSenha);
        _emailService.EnviarAsync(emailParams);
    }
}