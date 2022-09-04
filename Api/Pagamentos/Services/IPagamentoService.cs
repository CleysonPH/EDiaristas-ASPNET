using EDiaristas.Api.Pagamentos.Dtos;

namespace EDiaristas.Api.Pagamentos.Services;

public interface IPagamentoService
{
    ICollection<PagamentoResponse> Listar();
}