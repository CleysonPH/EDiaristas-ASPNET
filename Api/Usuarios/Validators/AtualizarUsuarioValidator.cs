using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.PasswordEnconder.Adapters;
using FluentValidation;

namespace EDiaristas.Api.Usuarios.Validators;

public class AtualizarUsuarioValidator : AbstractValidator<AtualizarUsuarioRequest>
{
    public AtualizarUsuarioValidator(
        IPasswordEnconderService passwordEnconderService,
        ICustomAuthenticationService customAuthenticationService,
        IUsuarioRepository usuarioRepository)
    {
        RuleFor(x => x.NomeCompleto)
            .MinimumLength(3).When(x => !string.IsNullOrEmpty(x.NomeCompleto))
            .WithMessage("devem ter no mínimo {MinLength} caracteres")
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.NomeCompleto))
            .WithMessage("devem ter no máximo {MaxLength} caracteres")
            .OverridePropertyName("nome_completo");

        RuleFor(x => x.Email)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("deve ser um e-mail válido")
            .MaximumLength(255).When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("devem ter no máximo {MaxLength} caracteres")
            .Must((request, email) => !usuarioRepository.ExistsByEmailAndNotId(email, request.Id)).When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("já está sendo utilizado por outro usuário")
            .OverridePropertyName("email");

        RuleFor(x => x.Cpf)
            .Length(11).When(x => !string.IsNullOrEmpty(x.Cpf))
            .WithMessage("deve ter {TotalLength} caracteres")
            .Must((request, cpf) => !usuarioRepository.ExistsByCpfAndNotId(cpf, request.Id)).When(x => !string.IsNullOrEmpty(x.Cpf))
            .WithMessage("já está sendo utilizado por outro usuário")
            .OverridePropertyName("cpf");

        RuleFor(x => x.Nascimento)
            .Must(nascimento => nascimento == null || (nascimento.GetIdade() >= 18 && nascimento.GetIdade() <= 100)).When(x => x.Nascimento != null)
            .WithMessage("deve ser maior de 18 anos e menor de 100 anos")
            .OverridePropertyName("nascimento");

        RuleFor(x => x.Telefone)
            .Length(11).When(x => !string.IsNullOrEmpty(x.Telefone))
            .WithMessage("deve ter {TotalLength} caracteres")
            .OverridePropertyName("telefone");

        RuleFor(x => x.ChavePix)
            .MinimumLength(11).When(x => !string.IsNullOrEmpty(x.ChavePix))
            .WithMessage("devem ter no mínimo {MinLength} caracteres")
            .MaximumLength(255).When(x => !string.IsNullOrEmpty(x.ChavePix))
            .WithMessage("devem ter no máximo {MaxLength} caracteres")
            .OverridePropertyName("chave_pix");

        RuleFor(x => x.Password)
            .Must(password =>
            {
                var usuario = customAuthenticationService.GetUsuarioAutenticado();
                return passwordEnconderService.Verify(password ?? string.Empty, usuario.Senha);
            }).When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("senha atual inválida")
            .OverridePropertyName("password");

        RuleFor(x => x.NewPassword)
            .MaximumLength(255)
            .WithMessage("devem ter no máximo {MaxLength} caracteres")
            .OverridePropertyName("new_password");

        RuleFor(x => x.PasswordConfirmation)
            .NotNull().When(x => !string.IsNullOrEmpty(x.NewPassword))
            .WithMessage("não pode ser nulo")
            .MaximumLength(255).When(x => !string.IsNullOrEmpty(x.NewPassword))
            .WithMessage("devem ter no máximo {MaxLength} caracteres")
            .Equal(x => x.NewPassword).When(x => !string.IsNullOrEmpty(x.NewPassword))
            .WithMessage("deve ser igual a 'new_password'")
            .OverridePropertyName("password_confirmation");
    }
}