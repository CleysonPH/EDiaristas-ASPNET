namespace EDiaristas.Api.Avaliacoes.Dtos;

public class AvalicaoResponse
{
    public string Descricao { get; set; } = string.Empty;
    public double Nota { get; set; }
    public string NomeAvaliador { get; set; } = string.Empty;
    public string FotoAvaliador { get; set; } = string.Empty;
}