namespace EDiaristas.Api.Pagamentos.Dtos;

public class PagamentoResponse
{
    public int Id { get; set; }
    public int Status { get; set; }
    public decimal Valor { get; set; }
    public decimal ValorDepoisto { get; set; }
    public DateTime CreatedAt { get; set; }
}