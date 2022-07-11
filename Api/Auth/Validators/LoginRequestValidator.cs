using EDiaristas.Api.Auth.Dtos;
using FluentValidation;

namespace EDiaristas.Api.Auth.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .EmailAddress()
            .WithMessage("deve ser um e-mail válido")
            .OverridePropertyName("email");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(6)
            .WithMessage("deve ter no mínimo 6 caracteres")
            .OverridePropertyName("password");
    }
}