using EDiaristas.Api.CidadesAtentidas.Dtos;

namespace EDiaristas.Api.CidadesAtentidas.Services;

public interface ICidadeAtendidaService
{
    ICollection<CidadeAtendidaResponse> ListarPorUsuarioLogado();
}