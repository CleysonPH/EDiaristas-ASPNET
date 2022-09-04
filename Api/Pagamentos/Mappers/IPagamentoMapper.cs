using EDiaristas.Api.Pagamentos.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Pagamentos.Mappers;

public interface IPagamentoMapper
{
    PagamentoResponse ToResponse(Pagamento pagamento);
}