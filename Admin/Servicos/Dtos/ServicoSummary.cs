namespace EDiaristas.Admin.Servicos.Dtos;

public class ServicoSummary
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal ValorMinimo { get; set; }
}