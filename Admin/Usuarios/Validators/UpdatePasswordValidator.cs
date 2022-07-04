using EDiaristas.Admin.Usuarios.Dtos;
using FluentValidation;

namespace EDiaristas.Admin.Usuarios.Validators;

public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordForm>
{
    public UpdatePasswordValidator()
    {
        RuleFor(x => x.SenhaAntiga)
            .NotEmpty()
            .WithMessage("não pode ser vazia.");

        RuleFor(x => x.NovaSenha)
            .NotEmpty()
            .WithMessage("não pode ser vazia.");

        RuleFor(x => x.NovaSenha)
            .MinimumLength(6)
            .WithMessage("deve ter no mínimo 6 caracteres.");

        RuleFor(x => x.ConfirmacaoNovaSenha)
            .NotEmpty()
            .WithMessage("não pode ser vazia.");

        RuleFor(x => x.ConfirmacaoNovaSenha)
            .Equal(x => x.NovaSenha)
            .WithMessage("senhas não são iguais.");
    }
}