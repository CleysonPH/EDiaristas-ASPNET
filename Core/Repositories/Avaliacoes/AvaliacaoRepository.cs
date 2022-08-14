using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Avaliacoes;

public class AvaliacaoRepository : IAvaliacaoRepository
{
    private readonly EDiaristasDbContext _context;

    public AvaliacaoRepository(EDiaristasDbContext context)
    {
        _context = context;
    }

    public Avaliacao Create(Avaliacao model)
    {
        _context.Avaliacoes.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var avaliacao = _context.Avaliacoes.Find(id);
        if (avaliacao is not null)
        {
            _context.Avaliacoes.Remove(avaliacao);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Avaliacoes.Any(a => a.Id == id);
    }

    public ICollection<Avaliacao> FindAll()
    {
        return _context.Avaliacoes.ToList();
    }

    public Avaliacao? FindById(int id)
    {
        return _context.Avaliacoes.Find(id);
    }

    public Avaliacao Update(Avaliacao model)
    {
        _context.Avaliacoes.Update(model);
        _context.SaveChanges();
        return model;
    }
}