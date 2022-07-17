using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.InvalidatedTokens;

public interface IInvalidatedTokenRepository : ICrudRepository<InvalidatedToken, int>
{
    bool ExistsByToken(string token);
}