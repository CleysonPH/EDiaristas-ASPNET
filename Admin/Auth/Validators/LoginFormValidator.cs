using EDiaristas.Admin.Auth.Dtos;
using FluentValidation;

namespace EDiaristas.Admin.Auth.Validators;

public class LoginFormValidator : AbstractValidator<LoginForm>
{
    public LoginFormValidator()
    {
        RuleFor(l => l.Email)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .EmailAddress()
            .WithMessage("precisa ser um endereço de e-mail válido");

        RuleFor(l => l.Senha)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(6)
            .WithMessage("precisa ter no mínimo 6 caracteres");
    }
}