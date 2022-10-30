using EDiaristas.Api.ResetSenha.Dtos;
using FluentValidation;

namespace EDiaristas.Api.ResetSenha.Validators;

public class ConfirmaResetSenhaValidator : AbstractValidator<ConfirmaResetSenhaRequest>
{
    public ConfirmaResetSenhaValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .EmailAddress()
            .WithMessage("não é um e-mail válido")
            .OverridePropertyName("email");

        RuleFor(x => x.Password)
            .NotNull()
            .WithMessage("é obrigatório")
            .NotEmpty()
            .WithMessage("é obrigatório")
            .OverridePropertyName("password");

        RuleFor(x => x.PasswordConfirmation)
            .NotNull()
            .WithMessage("é obrigatório")
            .NotEmpty()
            .WithMessage("é obrigatório")
            .Equal(x => x.Password)
            .WithMessage("não confere com a senha informada")
            .OverridePropertyName("password_confirmation");

        RuleFor(x => x.Token)
            .NotNull()
            .WithMessage("é obrigatório")
            .NotEmpty()
            .WithMessage("é obrigatório")
            .OverridePropertyName("token");
    }
}