using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.CidadesAtendidas;

public class CidadeAtendidaRepository : ICidadeAtendidaRepository
{
    private readonly EDiaristasDbContext _context;

    public CidadeAtendidaRepository(EDiaristasDbContext context)
    {
        _context = context;
    }

    public CidadeAtendida Create(CidadeAtendida model)
    {
        _context.CidadesAtendidas.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var cidadeAtendida = _context.CidadesAtendidas.Find(id);
        if (cidadeAtendida is not null)
        {
            _context.CidadesAtendidas.Remove(cidadeAtendida);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.CidadesAtendidas.Any(c => c.Id == id);
    }

    public ICollection<CidadeAtendida> FindAll()
    {
        return _context.CidadesAtendidas.ToList();
    }

    public CidadeAtendida? FindByCodigoIbge(string codigoIbge)
    {
        return _context.CidadesAtendidas.FirstOrDefault(c => c.CodigoIbge == codigoIbge);
    }

    public CidadeAtendida? FindById(int id)
    {
        return _context.CidadesAtendidas.Find(id);
    }

    public CidadeAtendida Update(CidadeAtendida model)
    {
        _context.CidadesAtendidas.Update(model);
        _context.SaveChanges();
        return model;
    }
}