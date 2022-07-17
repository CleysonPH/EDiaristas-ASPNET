using EDiaristas.Core.Models;

namespace EDiaristas.Core.Services.Token.Adapters;

public interface ITokenService
{
    string GenerateAccessToken(Usuario usuario);
    string GenerateRefreshToken(Usuario usuario);
    string GetEmailFromRefreshToken(string refreshToken);
    DateTime GetExpirationDateFromRefreshToken(string refreshToken);
}