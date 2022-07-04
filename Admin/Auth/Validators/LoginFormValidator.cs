using EDiaristas.Admin.Auth.Dtos;
using EDiaristas.Core.Repositories.Usuarios;
using FluentValidation;

namespace EDiaristas.Admin.Auth.Validators;

public class LoginFormValidator : AbstractValidator<LoginForm>
{
    public LoginFormValidator(IUsuarioRepository usuarioRepository)
    {
        RuleFor(l => l.Email)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .EmailAddress()
            .WithMessage("precisa ser um endereço de e-mail válido");

        When(l => !string.IsNullOrEmpty(l.Email), () =>
        {
            RuleFor(l => l.Email)
                .Must(email => usuarioRepository.ExistsByEmail(email))
                .WithMessage("não existe um usuário com este e-mail");
        });

        RuleFor(l => l.Senha)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(6)
            .WithMessage("precisa ter no mínimo 6 caracteres");
    }
}