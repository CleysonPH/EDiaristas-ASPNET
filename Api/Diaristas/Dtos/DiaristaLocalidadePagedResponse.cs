namespace EDiaristas.Api.Diaristas.Dtos;

public class DiaristaLocalidadePagedResponse
{
    public ICollection<DiaristaLocalidadeResponse> Diaristas { get; set; }
    public int QuantidadeDiaristas { get; set; }

    public DiaristaLocalidadePagedResponse(
        ICollection<DiaristaLocalidadeResponse> diaristas,
        int tamanhoPagina,
        int totalElementos)
    {
        Diaristas = diaristas;
        QuantidadeDiaristas = totalElementos > tamanhoPagina ? totalElementos - tamanhoPagina : 0;
    }
}