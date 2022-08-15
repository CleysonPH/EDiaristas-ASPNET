using EDiaristas.Api.Avaliacoes.Dtos;
using EDiaristas.Api.Common.Dtos;

namespace EDiaristas.Api.Avaliacoes.Services;

public interface IAvaliacaoService
{
    MessageResponse Avaliar(AvaliacaoRequest request, int diariaId);
}