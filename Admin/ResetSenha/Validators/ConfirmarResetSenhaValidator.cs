using EDiaristas.Admin.ResetSenha.Dtos;
using FluentValidation;

namespace EDiaristas.Admin.ResetSenha.Validators;

public class ConfirmarResetSenhaValidator : AbstractValidator<ConfirmarResetSenhaForm>
{
    public ConfirmarResetSenhaValidator()
    {
        RuleFor(x => x.Senha)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(6)
            .WithMessage("A senha deve ter no mínimo 6 caracteres");

        RuleFor(x => x.ConfirmarSenha)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(6)
            .WithMessage("A confirmação de senha deve ter no mínimo 6 caracteres")
            .Equal(x => x.Senha)
            .WithMessage("deve ser igual a senha");
    }
}