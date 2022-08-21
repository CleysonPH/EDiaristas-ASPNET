namespace EDiaristas.Core.Services.GatewayPagamento.PagarMe;

public class RefundRequest
{
    public string ApiKey { get; set; } = string.Empty;

    public RefundRequest(string apiKey)
    {
        ApiKey = apiKey;
    }
}