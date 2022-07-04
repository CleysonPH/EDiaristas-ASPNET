using EDiaristas.Admin.Usuarios.Dtos;
using EDiaristas.Core.Repositories.Usuarios;
using FluentValidation;

namespace EDiaristas.Admin.Usuarios.Validators;

public class UsuarioUpdateValidator : AbstractValidator<UsuarioUpdateForm>
{
    public UsuarioUpdateValidator(IUsuarioRepository usuarioRepository)
    {
        RuleFor(u => u.NomeCompleto)
            .NotEmpty()
            .WithMessage("é obrigatório");

        When(u => !string.IsNullOrWhiteSpace(u.NomeCompleto), () =>
        {
            RuleFor(u => u.NomeCompleto)
                .Must(nome => nome.Length > 3)
                .WithMessage("deve ter mais de 3 caracteres");

            RuleFor(u => u.NomeCompleto)
                .Must(nome => nome.Length <= 100)
                .WithMessage("deve conter até 100 caracteres");
        });

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("é obrigatório");

        When(u => !string.IsNullOrWhiteSpace(u.Email), () =>
        {
            RuleFor(u => u.Email)
                .Must(email => email.Length > 3)
                .WithMessage("deve ter mais de 3 caracteres");

            RuleFor(u => u.Email)
                .Must(email => email.Length <= 255)
                .WithMessage("deve conter até 255 caracteres");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("deve ser um endereço de e-mail válido");

            RuleFor(u => u)
                .Must(u => !usuarioRepository.ExistsByEmailAndNotId(u.Email, u.Id))
                .WithMessage("já existe um usuário com este e-mail")
                .OverridePropertyName("Email");
        });
    }
}