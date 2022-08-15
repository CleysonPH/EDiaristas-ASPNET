using EDiaristas.Api.Avaliacoes.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Avaliacoes.Mappers;

public interface IAvaliacaoMapper
{
    AvalicaoResponse ToResponse(Avaliacao model);
}