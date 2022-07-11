using EDiaristas.Core.Models;

namespace EDiaristas.Core.Services.Token.Adapters;

public interface ITokenService
{
    string GenerateAccessToken(Usuario usuario);
}