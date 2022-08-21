namespace EDiaristas.Core.Services.GatewayPagamento.PagarMe;

public class TransactionSuccessResponse
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public int Amount { get; set; }
}