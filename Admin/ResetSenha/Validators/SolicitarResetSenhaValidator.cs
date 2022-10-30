using EDiaristas.Admin.ResetSenha.Dtos;
using FluentValidation;

namespace EDiaristas.Admin.ResetSenha.Validators;

public class SolicitarResetSenhaValidator : AbstractValidator<SolicitarResetSenhaForm>
{
    public SolicitarResetSenhaValidator()
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("é obrigatório")
            .NotEmpty().WithMessage("é obrigatório")
            .EmailAddress().WithMessage("deve ser um e-mail válido");
    }
}