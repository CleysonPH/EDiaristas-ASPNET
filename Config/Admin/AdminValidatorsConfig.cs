using EDiaristas.Admin.Auth.Dtos;
using EDiaristas.Admin.Auth.Validators;
using EDiaristas.Admin.ResetSenha.Dtos;
using EDiaristas.Admin.ResetSenha.Validators;
using EDiaristas.Admin.Servicos.Dtos;
using EDiaristas.Admin.Servicos.Validators;
using EDiaristas.Admin.Usuarios.Dtos;
using EDiaristas.Admin.Usuarios.Validators;
using FluentValidation;

namespace EDiaristas.Config.Admin;

public static class AdminValidatorsConfig
{
    public static void RegisterAdminValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<ServicoForm>, ServiceFormValidator>();
        services.AddTransient<IValidator<UsuarioCreateForm>, UsuarioCreateValidator>();
        services.AddTransient<IValidator<UsuarioUpdateForm>, UsuarioUpdateValidator>();
        services.AddTransient<IValidator<LoginForm>, LoginFormValidator>();
        services.AddTransient<IValidator<UpdatePasswordForm>, UpdatePasswordValidator>();
        services.AddTransient<IValidator<SolicitarResetSenhaForm>, SolicitarResetSenhaValidator>();
        services.AddTransient<IValidator<ConfirmarResetSenhaForm>, ConfirmarResetSenhaValidator>();
    }
}