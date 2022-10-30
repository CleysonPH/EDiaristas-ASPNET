using EDiaristas.Api.ResetSenha.Dtos;
using FluentValidation;

namespace EDiaristas.Api.ResetSenha.Validators;

public class SolicitarResetSenhaValidator : AbstractValidator<SolicitarResetSenhaRequest>
{
    public SolicitarResetSenhaValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .EmailAddress()
            .WithMessage("não é um e-mail válido")
            .OverridePropertyName("email");
    }
}