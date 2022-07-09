using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Core.Repositories.Usuarios;
using FluentValidation;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Usuarios.Validators;

public class UsuarioRequestValidator : AbstractValidator<UsuarioRequest>
{
    public UsuarioRequestValidator(IUsuarioRepository usuarioRepository)
    {
        RuleFor(x => x.NomeCompleto)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(3)
            .WithMessage("deve ter no mínimo 3 caracteres")
            .MaximumLength(100)
            .WithMessage("deve ter no máximo 100 caracteres")
            .OverridePropertyName("nome_completo");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .EmailAddress()
            .WithMessage("deve ser um e-mail válido")
            .OverridePropertyName("email");

        When(x => !string.IsNullOrWhiteSpace(x.Email), () =>
        {
            RuleFor(x => x.Email)
                .Must(email => !usuarioRepository.ExistsByEmail(email))
                .WithMessage("já existe um usuário com este e-mail")
                .OverridePropertyName("email");
        });

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(6)
            .WithMessage("deve ter no mínimo 6 caracteres")
            .OverridePropertyName("password");

        RuleFor(x => x.PasswordConfirmation)
                .NotEmpty()
                .WithMessage("é obrigatório")
                .Equal(x => x.Password)
                .WithMessage("senhas não conferem")
                .OverridePropertyName("password_confirmation");

        RuleFor(x => x.TipoUsuario)
                .Must(x => x.IsCliente() || x.IsDiarista())
                .WithMessage("tipo de usuário inválido")
                .OverridePropertyName("tipo_usuario");

        RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("é obrigatório")
                .Length(11)
                .WithMessage("deve ter 11 caracteres")
                .OverridePropertyName("cpf");

        When(x => !string.IsNullOrWhiteSpace(x.Cpf), () =>
            {
                RuleFor(x => x.Cpf)
                .Must(cpf => !usuarioRepository.ExistsByCpf(cpf))
                .WithMessage("CPF já cadastrado")
                .OverridePropertyName("cpf");
            });

        RuleFor(x => x.Nascimento)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .Must(x => x.GetIdade() >= 18 && x.GetIdade() <= 100)
            .WithMessage("deve ser maior que 18 anos e menor que 100 anos")
            .OverridePropertyName("nascimento");

        RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("é obrigatório")
                .Length(11)
                .WithMessage("deve ter 11 caracteres")
                .OverridePropertyName("telefone");

        When(x => x.TipoUsuario.IsDiarista(), () =>
            {
                RuleFor(x => x.ChavePix)
                .NotEmpty()
                .WithMessage("é obrigatório")
                .MaximumLength(255)
                .WithMessage("deve ter no máximo 255 caracteres")
                .OverridePropertyName("chave_pix");
            });

        When(x => x.TipoUsuario.IsCliente(), () =>
        {
            RuleFor(x => x.ChavePix)
                .Empty()
                .WithMessage("não deve ser preenchido")
                .OverridePropertyName("chave_pix");
        });
    }
}