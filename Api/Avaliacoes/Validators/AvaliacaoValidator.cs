using EDiaristas.Api.Avaliacoes.Dtos;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Avaliacoes;
using FluentValidation;

namespace EDiaristas.Api.Avaliacoes.Validators;

public class AvaliacaoValidator : AbstractValidator<AvaliacaoData>
{
    public AvaliacaoValidator(IAvaliacaoRepository avaliacaoRepository)
    {
        RuleFor(a => a.Request.Descricao)
            .NotNull()
            .WithMessage("é obrigatória")
            .NotEmpty()
            .WithMessage("não pode ser vazia")
            .MinimumLength(3)
            .WithMessage("não pode ter menos que 3 caracteres")
            .MaximumLength(255)
            .WithMessage("não pode ter mais que 255 caracteres")
            .OverridePropertyName("descricao");

        RuleFor(a => a.Request.Nota)
            .NotNull()
            .WithMessage("é obrigatória")
            .GreaterThan(0)
            .WithMessage("não pode ser menor que 0")
            .LessThanOrEqualTo(5)
            .WithMessage("não pode ser maior que 5")
            .OverridePropertyName("nota");

        RuleFor(a => a.Diaria.Status)
            .Equal(DiariaStatus.Concluido)
            .WithMessage("só é possível avaliar uma diária concluída")
            .OverridePropertyName("diaria");

        RuleFor(a => a.Diaria.DataAtendimento)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("não pode ser uma diária futura")
            .OverridePropertyName("diaria");

        RuleFor(a => a)
            .Must(a => !avaliacaoRepository.ExistsByDiariaAndAvaliador(a.Diaria, a.Avaliador))
            .WithMessage("já avaliou esta diária")
            .OverridePropertyName("avaliador");
    }
}