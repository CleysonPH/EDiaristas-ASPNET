namespace EDiaristas.Api.Avaliacoes.Dtos;

public class AvaliacaoRequest
{
    public string Descricao { get; set; } = string.Empty;
    public double Nota { get; set; }
}