namespace EDiaristas.Core.Services.GatewayPagamento.PagarMe;

public class TransactionSuccessResponse
{
    public string Id { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int Amount { get; set; }
}