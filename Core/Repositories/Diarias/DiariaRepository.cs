using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Diarias;

public class DiariaRepository : IDiariaRepository
{
    private readonly EDiaristasDbContext _context;

    public DiariaRepository(EDiaristasDbContext context)
    {
        _context = context;
    }

    public Diaria Create(Diaria model)
    {
        _context.Diarias.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var diaria = _context.Diarias.Find(id);
        if (diaria != null)
        {
            _context.Diarias.Remove(diaria);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Diarias.Any(d => d.Id == id);
    }

    public bool ExistsByIdAndClienteId(int diariaId, int clienteId)
    {
        return _context.Diarias
            .Any(d => d.Id == diariaId && d.ClienteId == clienteId);
    }

    public bool ExistsByIdAndDiaristaId(int diariaId, int diaristaId)
    {
        return _context.Diarias
            .Any(d => d.Id == diariaId && d.DiaristaId == diaristaId);
    }

    public ICollection<Diaria> FindAll()
    {
        return _context.Diarias.ToList();
    }

    public ICollection<Diaria> FindByClienteId(int clienteId)
    {
        return _context.Diarias
            .Where(d => d.ClienteId == clienteId)
            .ToList();
    }

    public ICollection<Diaria> FindByDiaristaId(int diaristaId)
    {
        return _context.Diarias
            .Where(d => d.DiaristaId == diaristaId)
            .ToList();
    }

    public Diaria? FindById(int id)
    {
        return _context.Diarias.FirstOrDefault(d => d.Id == id);
    }

    public Diaria Update(Diaria model)
    {
        _context.Diarias.Update(model);
        _context.SaveChanges();
        return model;
    }
}