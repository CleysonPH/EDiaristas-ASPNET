using EDiaristas.Core.Models;

namespace EDiaristas.Api.Avaliacoes.Dtos;

public class AvaliacaoData
{
    public AvaliacaoRequest Request { get; set; }
    public Diaria Diaria { get; set; }
    public Usuario Avaliador { get; set; }

    public AvaliacaoData(AvaliacaoRequest request, Diaria diaria, Usuario avaliador)
    {
        Request = request;
        Diaria = diaria;
        Avaliador = avaliador;
    }
}