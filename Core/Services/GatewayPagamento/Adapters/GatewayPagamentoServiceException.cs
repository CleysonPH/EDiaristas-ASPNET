namespace EDiaristas.Core.Services.GatewayPagamento;

public class GatewayPagamentoServiceException : Exception
{
    public GatewayPagamentoServiceException(string message) : base(message)
    { }
}