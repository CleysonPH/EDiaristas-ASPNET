using EDiaristas.Api.Usuarios.Dtos;
using FluentValidation;

namespace EDiaristas.Api.Usuarios.Validators;

public class AtualizarFotoValidator : AbstractValidator<AtualizarFotoRequest>
{
    public AtualizarFotoValidator()
    {
        RuleFor(x => x.FotoUsuario)
            .NotNull()
            .WithMessage("é obrigatório");
        When(x => x.FotoUsuario is not null, () =>
        {
            RuleFor(x => x.FotoUsuario)
                .Must(x => x.Length > 0).WithMessage("é obrigatório")
                .Must(x => x.ContentType.StartsWith("image/")).WithMessage("deve ser uma imagem válida")
                .OverridePropertyName("foto_usuario");
        });
    }
}