using EDiaristas.Api.Avaliacoes.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Avaliacoes.Mappers;

public class AvaliacaoMapper : IAvaliacaoMapper
{
    public AvalicaoResponse ToResponse(Avaliacao model)
    {
        return new AvalicaoResponse
        {
            Descricao = model.Descricao,
            Nota = model.Nota,
            NomeAvaliador = model.Avaliador.NomeCompleto,
            FotoAvaliador = "",
        };
    }
}