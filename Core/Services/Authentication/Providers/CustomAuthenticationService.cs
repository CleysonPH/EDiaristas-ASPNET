using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.PasswordEnconder.Adapters;

namespace EDiaristas.Core.Services.Authentication.Providers;

public class CustomAuthenticationService : ICustomAuthenticationService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordEnconderService _passwordEnconderService;

    public CustomAuthenticationService(IUsuarioRepository usuarioRepository, IPasswordEnconderService passwordEnconderService)
    {
        _usuarioRepository = usuarioRepository;
        _passwordEnconderService = passwordEnconderService;
    }

    public Usuario Authenticate(string email, string password)
    {
        var usuario = _usuarioRepository.FindByEmail(email);
        if (usuario == null)
        {
            throw new InvalidCredentialsException();
        }
        if (!_passwordEnconderService.Verify(password, usuario.Senha))
        {
            throw new InvalidCredentialsException();
        }
        return usuario;
    }
}