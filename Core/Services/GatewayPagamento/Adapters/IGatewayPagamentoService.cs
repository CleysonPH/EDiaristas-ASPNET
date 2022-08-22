using EDiaristas.Core.Models;

namespace EDiaristas.Core.Services.GatewayPagamento;

public interface IGatewayPagamentoService
{
    Pagamento Pagar(Diaria diaria, string cardHash);
    Pagamento Estornar(Diaria diaria);
    Pagamento Estornar(Diaria diaria, decimal amount);
}
