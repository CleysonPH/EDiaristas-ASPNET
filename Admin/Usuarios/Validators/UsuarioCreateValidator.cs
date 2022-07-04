using EDiaristas.Admin.Usuarios.Dtos;
using EDiaristas.Core.Repositories.Usuarios;
using FluentValidation;

namespace EDiaristas.Admin.Usuarios.Validators;

public class UsuarioCreateValidator : AbstractValidator<UsuarioCreateForm>
{
    public UsuarioCreateValidator(IUsuarioRepository usuarioRepository)
    {
        RuleFor(u => u.NomeCompleto)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(3)
            .WithMessage("deve ter mais de 3 caracteres")
            .MaximumLength(100)
            .WithMessage("deve conter até 100 caracteres");

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(3)
            .WithMessage("deve ter mais de 3 caracteres")
            .MaximumLength(255)
            .WithMessage("deve conter até 255 caracteres")
            .EmailAddress()
            .WithMessage("deve ser um endereço de e-mail válido")
            .Must(email => !usuarioRepository.ExistsByEmail(email))
            .WithMessage("já existe um usuário com este e-mail");

        RuleFor(u => u.Senha)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(6)
            .WithMessage("deve ter no mínimo 6 caracteres");

        RuleFor(u => u.ConfirmacaoSenha)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .Equal(u => u.Senha)
            .WithMessage("deve ser igual a senha");
    }
}