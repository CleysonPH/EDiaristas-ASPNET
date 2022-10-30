using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.PasswordRestToken;

public class PasswordResetTokenRepository : IPasswordResetTokenRepository
{
    private readonly EDiaristasDbContext _context;

    public PasswordResetTokenRepository(EDiaristasDbContext context)
    {
        _context = context;
    }

    public PasswordResetToken? BuscarPorEmail(string email)
    {
        return _context.PasswordResetTokens.FirstOrDefault(x => x.Email == email);
    }

    public PasswordResetToken? BuscarPorToken(string token)
    {
        return _context.PasswordResetTokens.FirstOrDefault(x => x.Token == token);
    }

    public PasswordResetToken Create(PasswordResetToken model)
    {
        _context.PasswordResetTokens.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var model = _context.PasswordResetTokens.Find(id);
        if (model is not null)
        {
            _context.PasswordResetTokens.Remove(model);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.PasswordResetTokens.Any(x => x.Id == id);
    }

    public ICollection<PasswordResetToken> FindAll()
    {
        return _context.PasswordResetTokens.ToList();
    }

    public PasswordResetToken? FindById(int id)
    {
        return _context.PasswordResetTokens.Find(id);
    }

    public PasswordResetToken Update(PasswordResetToken model)
    {
        _context.PasswordResetTokens.Update(model);
        _context.SaveChanges();
        return model;
    }
}