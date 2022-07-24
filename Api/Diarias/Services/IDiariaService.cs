using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Diarias.Dtos;

namespace EDiaristas.Api.Diarias.Services;

public interface IDiariaService
{
    DiariaResponse Cadastrar(DiariaRequest request);
    MessageResponse Pagar(PagamentoRequest request, int diariaId);
    ICollection<DiariaResponse> ListarPeloUsuarioLogado();
    DiariaResponse BuscarPeloId(int diariaId);
}