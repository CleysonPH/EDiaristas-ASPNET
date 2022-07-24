using EDiaristas.Api.EnderecosDiarista.Dtos;
using EDiaristas.Core.Services.ConsultaEndereco.Adapters;
using EDiaristas.Core.Services.ConsultaEndereco.Exceptions;
using FluentValidation;

namespace EDiaristas.Api.EnderecosDiarista.Validators;

public class EnderecoDiaristaRequestValidator : AbstractValidator<EnderecoDiaristaRequest>
{
    public EnderecoDiaristaRequestValidator(IConsultaEnderecoService consultaEnderecoService)
    {
        RuleFor(x => x.Logradouro)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MaximumLength(100)
            .WithMessage("deve ter no máximo 100 caracteres")
            .OverridePropertyName("logradouro");

        RuleFor(x => x.Numero)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MaximumLength(10)
            .WithMessage("deve ter no máximo 10 caracteres")
            .OverridePropertyName("numero");

        RuleFor(x => x.Bairro)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MaximumLength(100)
            .WithMessage("deve ter no máximo 100 caracteres")
            .OverridePropertyName("bairro");

        RuleFor(x => x.Cidade)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MaximumLength(100)
            .WithMessage("deve ter no máximo 100 caracteres")
            .OverridePropertyName("cidade");

        RuleFor(x => x.Estado)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MaximumLength(2)
            .WithMessage("deve ter no máximo 2 caracteres")
            .OverridePropertyName("estado");

        RuleFor(x => x.Cep)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MaximumLength(8)
            .WithMessage("deve ter no máximo 8 caracteres")
            .OverridePropertyName("cep");

        When(x => !string.IsNullOrWhiteSpace(x.Cep), () =>
        {
            RuleFor(x => x.Cep)
                .Must(x =>
                {
                    try
                    {
                        consultaEnderecoService.FindEnderecoByCep(x);
                        return true;
                    }
                    catch (ConsultaEnderecoServiceException)
                    {
                        return false;
                    }
                })
                .WithMessage("CEP inválido")
                .OverridePropertyName("cep");
        });

        RuleFor(x => x.Complemento)
            .MaximumLength(100)
            .WithMessage("deve ter no máximo 100 caracteres")
            .OverridePropertyName("complemento");
    }
}