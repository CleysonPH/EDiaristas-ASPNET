using EDiaristas.Api.Pagamentos.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Pagamentos.Mappers;

public class PagamentoMapper : IPagamentoMapper
{
    public PagamentoResponse ToResponse(Pagamento pagamento)
    {
        return new PagamentoResponse
        {
            Id = pagamento.Id,
            Valor = pagamento.Diaria.Preco,
            ValorDepoisto = pagamento.Diaria.Preco - pagamento.Diaria.ValorComissao,
            Status = diariaStatusToInt(pagamento.Diaria.Status)
        };
    }

    private int diariaStatusToInt(DiariaStatus status)
    {
        return status == DiariaStatus.Transferido ? 1 : 2;
    }
}