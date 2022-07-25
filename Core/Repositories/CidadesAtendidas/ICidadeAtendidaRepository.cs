using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.CidadesAtendidas;

public interface ICidadeAtendidaRepository : ICrudRepository<CidadeAtendida, int>
{
    CidadeAtendida? FindByCodigoIbge(string codigoIbge);
}