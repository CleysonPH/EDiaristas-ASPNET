using EDiaristas.Api.Diarias.Mappers;
using EDiaristas.Api.Oportunidades.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Oportunidades.Mappers;

public class OportunidadeMapper : IOportunidadeMapper
{
    private readonly IDiariaMapper _diariaMapper;

    public OportunidadeMapper(IDiariaMapper diariaMapper)
    {
        _diariaMapper = diariaMapper;
    }

    public OportunidadeResponse ToResponse(Diaria diaria)
    {
        var diarisResponse = _diariaMapper.ToResponse(diaria);
        return new OportunidadeResponse
        {
            Id = diarisResponse.Id,
            Status = diarisResponse.Status,
            MotivoCancelamento = diarisResponse.MotivoCancelamento,
            NomeServico = diarisResponse.NomeServico,
            Complemento = diarisResponse.Complemento,
            DataAtendimento = diarisResponse.DataAtendimento,
            TempoAtendimento = diarisResponse.TempoAtendimento,
            Preco = diarisResponse.Preco,
            Logradouro = diarisResponse.Logradouro,
            Numero = diarisResponse.Numero,
            Bairro = diarisResponse.Bairro,
            Estado = diarisResponse.Estado,
            Cidade = diarisResponse.Cidade,
            CodigoIbge = diarisResponse.CodigoIbge,
            QuantidadeQuartos = diarisResponse.QuantidadeQuartos,
            QuantidadeSalas = diarisResponse.QuantidadeSalas,
            QuantidadeCozinhas = diarisResponse.QuantidadeCozinhas,
            QuantidadeBanheiros = diarisResponse.QuantidadeBanheiros,
            QuantidadeQuintais = diarisResponse.QuantidadeQuintais,
            QuantidadeOutros = diarisResponse.QuantidadeOutros,
            Observacoes = diarisResponse.Observacoes,
            Servico = diarisResponse.Servico,
            Cliente = diarisResponse.Cliente,
            Diarista = diarisResponse.Diarista,
        };
    }
}