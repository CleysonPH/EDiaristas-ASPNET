namespace EDiaristas.Api.Diaristas.Dtos;

public class DiaristaLocalidadeResponse
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public double Reputacao { get; set; }
    public string FotoUsuario { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
}