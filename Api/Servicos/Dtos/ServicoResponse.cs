namespace EDiaristas.Api.Servicos.Dtos;

public class ServicoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal ValorMinimo { get; set; }
    public int QtdHoras { get; set; }
    public decimal PorcentagemComissao { get; set; }
    public int HorasQuarto { get; set; }
    public decimal ValorQuarto { get; set; }
    public int HorasSala { get; set; }
    public decimal ValorSala { get; set; }
    public int HorasBanheiro { get; set; }
    public decimal ValorBanheiro { get; set; }
    public int HorasCozinha { get; set; }
    public decimal ValorCozinha { get; set; }
    public int HorasQuintal { get; set; }
    public decimal ValorQuintal { get; set; }
    public int HorasOutros { get; set; }
    public decimal ValorOutros { get; set; }
    public string Icone { get; set; } = string.Empty;
    public int Posicao { get; set; }
}