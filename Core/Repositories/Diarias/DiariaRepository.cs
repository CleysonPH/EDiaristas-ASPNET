using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;

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
        return _context.Diarias.AsNoTracking().Any(d => d.Id == id);
    }

    public bool ExistsByIdAndClienteId(int diariaId, int clienteId)
    {
        return _context.Diarias
            .AsNoTracking()
            .Any(d => d.Id == diariaId && d.ClienteId == clienteId);
    }

    public ICollection<Diaria> FindAll()
    {
        return _context.Diarias.AsNoTracking().ToList();
    }

    public Diaria? FindById(int id)
    {
        return _context.Diarias.AsNoTracking().FirstOrDefault(d => d.Id == id);
    }

    public Diaria Update(Diaria model)
    {
        _context.Diarias.Update(model);
        _context.SaveChanges();
        return model;
    }
}