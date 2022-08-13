using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Models;
using FluentValidation;

namespace EDiaristas.Api.Diarias.Validators;

public class ConfirmacaoPresencaValidator : AbstractValidator<ConfirmacaoPresencaData>
{
    public ConfirmacaoPresencaValidator()
    {
        RuleFor(x => x.Diaria.Status)
            .Equal(DiariaStatus.Confirmado)
            .WithMessage("diária não está confirmada")
            .OverridePropertyName("status");

        RuleFor(x => x.Diaria.DataAtendimento)
            .LessThan(DateTime.Now)
            .WithMessage("diária ainda não foi atendida")
            .OverridePropertyName("data_atendimento");

        RuleFor(x => x.Diaria.Diarista)
            .NotNull()
            .WithMessage("diária não possui diarista")
            .OverridePropertyName("diarista");
    }
}