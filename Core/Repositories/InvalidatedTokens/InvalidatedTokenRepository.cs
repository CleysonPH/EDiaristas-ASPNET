using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Repositories.InvalidatedTokens;

public class InvalidatedTokenRepository : IInvalidatedTokenRepository
{
    private readonly EDiaristasDbContext _context;

    public InvalidatedTokenRepository(EDiaristasDbContext context)
    {
        _context = context;
    }

    public InvalidatedToken Create(InvalidatedToken model)
    {
        _context.InvalidatedTokens.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var model = _context.InvalidatedTokens.Find(id);
        if (model != null)
        {
            _context.InvalidatedTokens.Remove(model);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.InvalidatedTokens.AsNoTracking().Any(x => x.Id == id);
    }

    public bool ExistsByToken(string token)
    {
        return _context.InvalidatedTokens.AsNoTracking().Any(x => x.Token == token);
    }

    public ICollection<InvalidatedToken> FindAll()
    {
        return _context.InvalidatedTokens.AsNoTracking().ToList();
    }

    public InvalidatedToken? FindById(int id)
    {
        return _context.InvalidatedTokens.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public InvalidatedToken Update(InvalidatedToken model)
    {
        _context.InvalidatedTokens.Update(model);
        _context.SaveChanges();
        return model;
    }
}