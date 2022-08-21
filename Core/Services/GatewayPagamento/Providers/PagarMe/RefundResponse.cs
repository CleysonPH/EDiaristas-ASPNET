namespace EDiaristas.Core.Services.GatewayPagamento.PagarMe;

public class RefundResponse
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public int Amount { get; set; }
    public int RefundedAmount { get; set; }
}