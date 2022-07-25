using EDiaristas.Api.CidadesAtentidas.Dtos;
using EDiaristas.Core.Services.ConsultaCidade.Adapters;
using FluentValidation;

namespace EDiaristas.Api.CidadesAtentidas.Validators;

public class CidadesAtendidasRequestValidator : AbstractValidator<CidadesAtendidasRequest>
{
    public CidadesAtendidasRequestValidator(IConsultaCidadeService consultaCidadeService)
    {
        RuleFor(x => x.Cidades)
            .NotEmpty()
            .WithMessage("é necessário informar ao menos uma cidade para atendimento.")
            .Must(x => x.Count == x.Select(y => y.Cidade).Distinct().Count())
            .WithMessage("é necessário informar cidades diferentes para atendimento.")
            .Must(x => x.Count == x.Select(y => y.CodigoIbge).Distinct().Count())
            .WithMessage("é necessário informar códigos IBGE diferentes para atendimento.")
            .OverridePropertyName("cidades");

        RuleForEach(x => x.Cidades)
            .SetValidator(new CidadeAtendidaRequestValidator(consultaCidadeService))
            .OverridePropertyName("cidades");
    }
}

public class CidadeAtendidaRequestValidator : AbstractValidator<CidadeAtendidaRequest>
{
    public CidadeAtendidaRequestValidator(IConsultaCidadeService consultaCidadeService)
    {
        RuleFor(x => x.Cidade)
            .NotEmpty()
            .WithMessage("é necessário informar a cidade para atendimento.")
            .MaximumLength(100)
            .WithMessage("a cidade deve ter no máximo 100 caracteres.")
            .OverridePropertyName("cidade");

        RuleFor(x => x.CodigoIbge)
            .NotEmpty()
            .WithMessage("é necessário informar o código IBGE para atendimento.")
            .OverridePropertyName("codigo_ibge");

        When(x => !string.IsNullOrEmpty(x.CodigoIbge), () =>
        {
            RuleFor(x => x.CodigoIbge)
                .Must(x =>
                {
                    try
                    {
                        consultaCidadeService.BuscarCidadePorCodigoIbge(x);
                        return true;
                    }
                    catch (ConsultaCidadeException)
                    {
                        return false;
                    }
                })
                .WithMessage("código IBGE informado não existe.")
                .OverridePropertyName("codigo_ibge");
        });
    }
}