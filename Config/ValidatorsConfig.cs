using EDiaristas.Admin.Auth.Dtos;
using EDiaristas.Admin.Auth.Validators;
using EDiaristas.Admin.Servicos.Dtos;
using EDiaristas.Admin.Servicos.Validators;
using EDiaristas.Admin.Usuarios.Dtos;
using EDiaristas.Admin.Usuarios.Validators;
using FluentValidation;

namespace EDiaristas.Config;

public static class ValidatorsConfig
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<ServicoForm>, ServiceFormValidator>();
        services.AddTransient<IValidator<UsuarioCreateForm>, UsuarioCreateValidator>();
        services.AddTransient<IValidator<UsuarioUpdateForm>, UsuarioUpdateValidator>();
        services.AddTransient<IValidator<LoginForm>, LoginFormValidator>();
        services.AddTransient<IValidator<UpdatePasswordForm>, UpdatePasswordValidator>();
    }
}