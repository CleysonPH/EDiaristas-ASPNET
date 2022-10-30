using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.PasswordRestToken;

public class PasswordResetTokenRepository : AbstractRepository<PasswordResetToken>, IPasswordResetTokenRepository
{
    public PasswordResetTokenRepository(EDiaristasDbContext context) : base(context)
    { }

    public PasswordResetToken? BuscarPorEmail(string email)
    {
        return context.PasswordResetTokens.FirstOrDefault(x => x.Email == email);
    }

    public PasswordResetToken? BuscarPorToken(string token)
    {
        return context.PasswordResetTokens.FirstOrDefault(x => x.Token == token);
    }
}