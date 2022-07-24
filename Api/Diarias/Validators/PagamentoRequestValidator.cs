using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Models;
using FluentValidation;

namespace EDiaristas.Api.Diarias.Validators;

public class PagamentoRequestValidator : AbstractValidator<PagamentoRequest>
{
    public PagamentoRequestValidator()
    {
        RuleFor(x => x.CardHash)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .OverridePropertyName("card_hash");

        RuleFor(x => x.DiariaStatus)
            .Must(x => x == DiariaStatus.SemPagamento)
            .WithMessage("só é permitido pagar uma diária sem pagamento")
            .OverridePropertyName("diaria_status");
    }
}