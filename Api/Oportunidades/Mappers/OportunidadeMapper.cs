using EDiaristas.Api.Avaliacoes.Dtos;
using EDiaristas.Api.Avaliacoes.Mappers;
using EDiaristas.Api.Diarias.Mappers;
using EDiaristas.Api.Oportunidades.Dtos;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Avaliacoes;

namespace EDiaristas.Api.Oportunidades.Mappers;

public class OportunidadeMapper : IOportunidadeMapper
{
    private readonly IDiariaMapper _diariaMapper;
    private readonly IAvaliacaoMapper _avaliacaoMapper;
    private readonly IAvaliacaoRepository _avaliacaoRepository;

    public OportunidadeMapper(
        IDiariaMapper diariaMapper,
        IAvaliacaoMapper avaliacaoMapper,
        IAvaliacaoRepository avaliacaoRepository)
    {
        _diariaMapper = diariaMapper;
        _avaliacaoMapper = avaliacaoMapper;
        _avaliacaoRepository = avaliacaoRepository;
    }

    public OportunidadeResponse ToResponse(Diaria diaria)
    {
        var diariaResponse = _diariaMapper.ToResponse(diaria);
        return new OportunidadeResponse
        {
            Id = diariaResponse.Id,
            Status = diariaResponse.Status,
            MotivoCancelamento = diariaResponse.MotivoCancelamento,
            NomeServico = diariaResponse.NomeServico,
            Complemento = diariaResponse.Complemento,
            DataAtendimento = diariaResponse.DataAtendimento,
            TempoAtendimento = diariaResponse.TempoAtendimento,
            Preco = diariaResponse.Preco,
            Logradouro = diariaResponse.Logradouro,
            Numero = diariaResponse.Numero,
            Bairro = diariaResponse.Bairro,
            Estado = diariaResponse.Estado,
            Cidade = diariaResponse.Cidade,
            CodigoIbge = diariaResponse.CodigoIbge,
            QuantidadeQuartos = diariaResponse.QuantidadeQuartos,
            QuantidadeSalas = diariaResponse.QuantidadeSalas,
            QuantidadeCozinhas = diariaResponse.QuantidadeCozinhas,
            QuantidadeBanheiros = diariaResponse.QuantidadeBanheiros,
            QuantidadeQuintais = diariaResponse.QuantidadeQuintais,
            QuantidadeOutros = diariaResponse.QuantidadeOutros,
            Observacoes = diariaResponse.Observacoes,
            Servico = diariaResponse.Servico,
            Cliente = diariaResponse.Cliente,
            Diarista = diariaResponse.Diarista,
            AvaliacoesCliente = getAvaliacoesCliente(diaria.ClienteId)
        };
    }

    private ICollection<AvalicaoResponse> getAvaliacoesCliente(int clienteId)
    {
        return _avaliacaoRepository.FindByAvaliadoId(clienteId, 2)
            .Select(avaliacao => _avaliacaoMapper.ToResponse(avaliacao))
            .ToList();
    }
}