namespace EDiaristas.Core.Services.GatewayPagamento.PagarMe;

public partial class TransactionErrorResponse
{
    public IList<Error> Errors { get; set; } = new List<Error>();
}

public partial class Error
{
    public string Message { get; set; } = string.Empty;
}