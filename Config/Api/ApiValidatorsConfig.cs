using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Api.Usuarios.Validators;
using FluentValidation;

namespace EDiaristas.Config.Api;

public static class ApiValidatorsConfig
{
    public static void RegisterApiValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<UsuarioRequest>, UsuarioRequestValidator>();
    }
}