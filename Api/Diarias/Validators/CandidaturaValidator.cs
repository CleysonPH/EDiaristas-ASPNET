using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Models;
using FluentValidation;

namespace EDiaristas.Api.Diarias.Validators;

public class CandidaturaValidator : AbstractValidator<CandidaturaData>
{
    public CandidaturaValidator()
    {
        RuleFor(x => x)
            .Must(x => x.Diaria.Candidatos.Count() < 3)
            .WithMessage("diária já possui o número máximo de candidaturas")
            .Must(x => !x.Diaria.Candidatos.Any(c => c.Id == x.Candidato.Id))
            .WithMessage("candidato já se candidatou para esta diária")
            .Must(x => x.Diaria.DiaristaId == null)
            .WithMessage("diária já possui diarista")
            .Must(x => x.Candidato.Endereco != null)
            .WithMessage("candidato não possui endereço")
            .Must(x => x.Candidato.CidadesAtendidas.Any(c => c.CodigoIbge == x.Diaria.CodigoIbge))
            .WithMessage("candidato não atende a cidade da diária")
            .OverridePropertyName("candidatos");

        RuleFor(x => x.Diaria.Status)
            .Must(x => x == DiariaStatus.Pago)
            .WithMessage("diária não está paga")
            .OverridePropertyName("status");

        RuleFor(x => x.Diaria.DataAtendimento)
            .Must(x => x >= DateTime.Today)
            .WithMessage("diária com data de atendiemento anterior a data atual")
            .OverridePropertyName("data_atendimento");
    }
}