using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.CidadesAtendidas;

public class CidadeAtendidaRepository : AbstractRepository<CidadeAtendida>, ICidadeAtendidaRepository
{
    public CidadeAtendidaRepository(EDiaristasDbContext context) : base(context)
    { }

    public CidadeAtendida? FindByCodigoIbge(string codigoIbge)
    {
        return context.CidadesAtendidas.FirstOrDefault(c => c.CodigoIbge == codigoIbge);
    }
}