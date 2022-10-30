using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.PasswordRestToken;

public interface IPasswordResetTokenRepository : ICrudRepository<PasswordResetToken, int>
{
    PasswordResetToken? BuscarPorToken(string token);
    PasswordResetToken? BuscarPorEmail(string email);
}