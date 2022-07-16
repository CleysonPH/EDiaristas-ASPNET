using EDiaristas.Core.Models;

namespace EDiaristas.Core.Services.Authentication.Adapters;

public interface ICustomAuthenticationService
{
    Usuario Authenticate(string email, string password);
    Usuario Authenticate(string refreshToken);
    Usuario GetUsuarioAutenticado();
}