using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Models;
using FluentValidation;

namespace EDiaristas.Api.Diarias.Validators;

public class CancelamentoValidator : AbstractValidator<CancelamentoRequest>
{
    public CancelamentoValidator()
    {
        RuleFor(x => x.MotivoCancelamento)
            .NotNull()
            .WithMessage("é obrigatório")
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MinimumLength(10)
            .WithMessage("deve ter no mínimo 10 caracteres")
            .MaximumLength(255)
            .WithMessage("deve ter no máximo 255 caracteres")
            .OverridePropertyName("motivo_cancelamento");

        RuleFor(x => x.Diaria.Status)
            .Must(x => new[] { DiariaStatus.Pago, DiariaStatus.Confirmado }.Contains(x))
            .WithMessage("diária deve estar em um dos status 'Pago' ou 'Confirmado'")
            .OverridePropertyName("status");

        RuleFor(x => x.Diaria.DataAtendimento)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("diária deve estar no futuro")
            .OverridePropertyName("data_atendimento");
    }
}