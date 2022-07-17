using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Servicos;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.ConsultaEndereco.Adapters;
using EDiaristas.Core.Services.ConsultaEndereco.Exceptions;
using FluentValidation;

namespace EDiaristas.Api.Diarias.Validators;

public class DiariaRequestValidator : AbstractValidator<DiariaRequest>
{
    public DiariaRequestValidator(
        IServicoRepository servicoRepository,
        IUsuarioRepository usuarioRepository,
        IConsultaEnderecoService consultaEnderecoService)
    {
        RuleFor(x => x.DataAtendimento)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .Must(x => x > DateTime.Now)
            .WithMessage("deve ser maior que a data atual")
            .Must(x => x.Hour >= 6)
            .WithMessage("a hora deve ser maior ou igual a 6")
            .Must(x => x < DateTime.Now.AddHours(48))
            .WithMessage("deve ser menor que 48 horas da data atual")
            .OverridePropertyName("data_atendimento");

        RuleFor(x => x.TempoAtendimento)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0")
            .OverridePropertyName("tempo_atendimento");

        RuleFor(x => x.Preco)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0")
            .OverridePropertyName("preco");

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

        RuleFor(x => x.Complemento)
            .MaximumLength(100)
            .WithMessage("deve ter no máximo 100 caracteres")
            .OverridePropertyName("complemento");

        RuleFor(x => x.Cidade)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MaximumLength(100)
            .WithMessage("deve ter no máximo 100 caracteres")
            .OverridePropertyName("cidade");

        RuleFor(x => x.Estado)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .Length(2)
            .WithMessage("deve ter 2 caracteres")
            .OverridePropertyName("estado");

        RuleFor(x => x.Cep)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .Length(8)
            .WithMessage("deve ter 8 caracteres")
            .OverridePropertyName("cep");

        RuleFor(x => x.CodigoIbge)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .MaximumLength(30)
            .WithMessage("deve ter no máximo 30 caracteres")
            .OverridePropertyName("codigo_ibge");

        RuleFor(x => x.QuantidadeQuartos)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .GreaterThanOrEqualTo(0)
            .WithMessage("deve ser maior ou igual a 0")
            .OverridePropertyName("quantidade_quartos");

        RuleFor(x => x.QuantidadeSalas)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .GreaterThanOrEqualTo(0)
            .WithMessage("deve ser maior ou igual a 0")
            .OverridePropertyName("quantidade_salas");

        RuleFor(x => x.QuantidadeCozinhas)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .GreaterThanOrEqualTo(0)
            .WithMessage("deve ser maior ou igual a 0")
            .OverridePropertyName("quantidade_cozinhas");

        RuleFor(x => x.QuantidadeBanheiros)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .GreaterThanOrEqualTo(0)
            .WithMessage("deve ser maior ou igual a 0")
            .OverridePropertyName("quantidade_banheiros");

        RuleFor(x => x.QuantidadeQuintais)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .GreaterThanOrEqualTo(0)
            .WithMessage("deve ser maior ou igual a 0")
            .OverridePropertyName("quantidade_quintais");

        RuleFor(x => x.QuantidadeOutros)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .GreaterThanOrEqualTo(0)
            .WithMessage("deve ser maior ou igual a 0")
            .OverridePropertyName("quantidade_outros");

        RuleFor(x => x.Observacoes)
            .MaximumLength(255)
            .WithMessage("deve ter no máximo 255 caracteres")
            .OverridePropertyName("observacoes");

        RuleFor(x => x.Servico)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .Must(x => servicoRepository.ExistsById(x))
            .OverridePropertyName("servico");

        RuleFor(x => x)
            .Must(x =>
            {
                var dataTermino = x.DataAtendimento.AddHours(x.TempoAtendimento);
                var dataLimite = new DateTime(
                    year: x.DataAtendimento.Year,
                    month: x.DataAtendimento.Month,
                    day: x.DataAtendimento.Day,
                    hour: 22,
                    minute: 0,
                    second: 0
                );
                return dataTermino <= dataLimite;
            })
            .WithMessage("a diária deve terminar antes das 22:00")
            .OverridePropertyName("data_termino");

        RuleFor(x => x)
            .Must(x =>
            {
                var servico = servicoRepository.FindById(x.Servico);
                return servico != null
                    && x.TempoAtendimento == calcularTempoAtendimento(x, servico);
            })
            .WithMessage("não corresponde ao serviço selecionado")
            .OverridePropertyName("tempo_atendimento");

        RuleFor(x => x)
            .Must(x =>
            {
                var servico = servicoRepository.FindById(x.Servico);
                return servico != null
                    && x.Preco == calcularPreco(x, servico);
            })
            .WithMessage("não corresponde ao serviço selecionado")
            .OverridePropertyName("preco");

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
                .WithMessage("cep não encontrado")
                .OverridePropertyName("cep");
        });

        When(x => !string.IsNullOrWhiteSpace(x.CodigoIbge), () =>
        {
            RuleFor(x => x.CodigoIbge)
                .Must(x => usuarioRepository.ExistsByCidadesAtendidasCodigoIbge(x))
                .WithMessage("não há diaristas que atendem a cidade selecionada")
                .OverridePropertyName("codigo_ibge");
            // validar se o código ibge é existe
        });
    }

    private int calcularTempoAtendimento(DiariaRequest diariaRequest, Servico servico)
    {
        return diariaRequest.QuantidadeQuartos * servico.HorasQuarto
            + diariaRequest.QuantidadeSalas * servico.HorasSala
            + diariaRequest.QuantidadeCozinhas * servico.HorasCozinha
            + diariaRequest.QuantidadeBanheiros * servico.HorasBanheiro
            + diariaRequest.QuantidadeQuintais * servico.HorasQuintal
            + diariaRequest.QuantidadeOutros * servico.HorasOutros;
    }

    private decimal calcularPreco(DiariaRequest diariaRequest, Servico servico)
    {
        var preco = diariaRequest.QuantidadeQuartos * servico.ValorQuarto
            + diariaRequest.QuantidadeSalas * servico.ValorSala
            + diariaRequest.QuantidadeCozinhas * servico.ValorCozinha
            + diariaRequest.QuantidadeBanheiros * servico.ValorBanheiro
            + diariaRequest.QuantidadeQuintais * servico.ValorQuintal
            + diariaRequest.QuantidadeOutros * servico.ValorOutros;
        return preco < servico.ValorMinimo ? servico.ValorMinimo : preco;
    }
}