using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Repositories.Servicos;

public class ServicoRepository : IServicoRepository
{
    private readonly EDiaristasDbContext _context;

    public ServicoRepository(EDiaristasDbContext context)
    {
        _context = context;
    }

    public Servico Create(Servico model)
    {
        _context.Servicos.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var servico = _context.Servicos.Find(id);
        if (servico is not null)
        {
            _context.Servicos.Remove(servico);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Servicos.AsNoTracking().Any(s => s.Id == id);
    }

    public ICollection<Servico> FindAll()
    {
        return _context.Servicos.AsNoTracking().ToList();
    }

    public ICollection<Servico> FindAll<TKey>(Func<Servico, TKey> keySelector)
    {
        return _context.Servicos.AsNoTracking().OrderBy(keySelector).ToList();
    }

    public Servico? FindById(int id)
    {
        return _context.Servicos.AsNoTracking().FirstOrDefault(s => s.Id == id);
    }

    public Servico Update(Servico model)
    {
        _context.Servicos.Update(model);
        _context.SaveChanges();
        return model;
    }
}