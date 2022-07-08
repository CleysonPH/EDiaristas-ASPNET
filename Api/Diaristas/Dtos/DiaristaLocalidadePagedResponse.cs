namespace EDiaristas.Api.Diaristas.Dtos;

public class DiaristaLocalidadePagedResponse
{
    public ICollection<DiaristaLocalidadeResponse> Diaristas { get; set; }
    public int QunatidadeDiaristas { get; set; }

    public DiaristaLocalidadePagedResponse(
        ICollection<DiaristaLocalidadeResponse> diaristas,
        int tamanhoPagina,
        int totalElementos)
    {
        Diaristas = diaristas;
        QunatidadeDiaristas = totalElementos > tamanhoPagina ? totalElementos - tamanhoPagina : 0;
    }
}