namespace EDiaristas.Core.Services.GatewayPagamento.PagarMe;

public class RefundRequest
{
    public string ApiKey { get; set; } = string.Empty;
    public int? Amount { get; set; }

    public RefundRequest(string apiKey, int? amount = null)
    {
        ApiKey = apiKey;
        Amount = amount;
    }
}