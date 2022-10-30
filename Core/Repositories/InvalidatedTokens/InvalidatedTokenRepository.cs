using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Repositories.InvalidatedTokens;

public class InvalidatedTokenRepository : AbstractRepository<InvalidatedToken>, IInvalidatedTokenRepository
{
    public InvalidatedTokenRepository(EDiaristasDbContext context) : base(context)
    { }

    public bool ExistsByToken(string token)
    {
        return context.InvalidatedTokens.AsNoTracking().Any(x => x.Token == token);
    }
}