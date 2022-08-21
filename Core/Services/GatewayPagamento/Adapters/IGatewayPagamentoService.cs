using EDiaristas.Core.Models;

namespace EDiaristas.Core.Services.GatewayPagamento;

public interface IGatewayPagamentoService
{
    Pagamento pagar(Diaria diaria, string cardHash);
}
