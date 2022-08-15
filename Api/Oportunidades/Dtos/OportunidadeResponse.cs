using EDiaristas.Api.Avaliacoes.Dtos;
using EDiaristas.Api.Diarias.Dtos;

namespace EDiaristas.Api.Oportunidades.Dtos;

public class OportunidadeResponse : DiariaResponse
{
    public ICollection<AvalicaoResponse> AvaliacoesCliente { get; set; } = new List<AvalicaoResponse>();
}