namespace EDiaristas.Core.Services.GatewayPagamento.PagarMe;

public class TransactionRequest
{
    public string ApiKey { get; set; } = string.Empty;
    public int Amount { get; set; }
    public string CardHash { get; set; } = string.Empty;
    public bool Async { get; set; }
}