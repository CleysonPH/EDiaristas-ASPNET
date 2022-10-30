using EDiaristas.Admin.ResetSenha.Dtos;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Services.Email;
using EDiaristas.Core.Services.PasswordReset.Adapters;
using FluentValidation;

namespace EDiaristas.Admin.ResetSenha.Services;

public class ResetSenhaService : IResetSenhaService
{
    private readonly String _backEndUrl;
    private readonly IEmailService _emailService;
    private readonly IPasswordResetService _passwordResetService;
    private readonly IValidator<SolicitarResetSenhaForm> _solicitarResetSenhaValidator;
    private readonly IValidator<ConfirmarResetSenhaForm> _confirmarResetSenhaValidator;

    public ResetSenhaService(
        IEmailService emailService,
        IConfiguration configuration,
        IPasswordResetService passwordResetService,
        IValidator<SolicitarResetSenhaForm> solicitarResetSenhaValidator,
        IValidator<ConfirmarResetSenhaForm> confirmarResetSenhaValidator)
    {
        _emailService = emailService;
        _passwordResetService = passwordResetService;
        _solicitarResetSenhaValidator = solicitarResetSenhaValidator;
        _confirmarResetSenhaValidator = confirmarResetSenhaValidator;
        var backendHost = configuration.GetValue<string>("Backend:Host");
        var backendResetPasswordPath = configuration.GetValue<string>("Backend:ResetPasswordPath");
        _backEndUrl = $"{backendHost}{backendResetPasswordPath}";
    }

    public void ConfirmarResetSenha(string token, ConfirmarResetSenhaForm confirmarResetSenhaForm)
    {
        _confirmarResetSenhaValidator.ValidateAndThrow(confirmarResetSenhaForm);
        _passwordResetService.ResetarSenha(token, confirmarResetSenhaForm.Senha);
    }

    public void SolicitarResetSenha(SolicitarResetSenhaForm solicitarResetSenhaForm)
    {
        try
        {
            trySolicitarResetSenha(solicitarResetSenhaForm);
        }
        catch (UsuarioNotFoundException)
        {
            // Não faz nada, pois não queremos dar pistas para invasores
        }
    }

    private void trySolicitarResetSenha(SolicitarResetSenhaForm solicitarResetSenhaForm)
    {
        _solicitarResetSenhaValidator.ValidateAndThrow(solicitarResetSenhaForm);
        var passwordResetToken = _passwordResetService.CriarPasswordResetToken(solicitarResetSenhaForm.Email);
        var passwordResetUrl = $"{_backEndUrl}?token={passwordResetToken}";
        var emailParams = new EmailParams(
            assunto: "Solicitação de redefinição de senha",
            destinatario: solicitarResetSenhaForm.Email,
            props: new Dictionary<string, string>
            {
                    { "Link", passwordResetUrl }
            },
            template: EmailParams.TemplateOptions.ResetSenha);
        _emailService.EnviarAsync(emailParams);
    }
}