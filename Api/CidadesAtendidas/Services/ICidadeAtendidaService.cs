using EDiaristas.Api.CidadesAtentidas.Dtos;
using EDiaristas.Api.Common.Dtos;

namespace EDiaristas.Api.CidadesAtentidas.Services;

public interface ICidadeAtendidaService
{
    ICollection<CidadeAtendidaResponse> ListarPorUsuarioLogado();
    MessageResponse Atualizar(CidadesAtendidasRequest request);
}