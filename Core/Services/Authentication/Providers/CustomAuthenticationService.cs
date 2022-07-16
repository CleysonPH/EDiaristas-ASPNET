using System.Security.Claims;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.PasswordEnconder.Adapters;
using EDiaristas.Core.Services.Token.Adapters;

namespace EDiaristas.Core.Services.Authentication.Providers;

public class CustomAuthenticationService : ICustomAuthenticationService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordEnconderService _passwordEnconderService;
    private readonly ITokenService _tokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomAuthenticationService(
        IUsuarioRepository usuarioRepository,
        IPasswordEnconderService passwordEnconderService,
        ITokenService tokenService,
        IHttpContextAccessor httpContextAccessor)
    {
        _usuarioRepository = usuarioRepository;
        _passwordEnconderService = passwordEnconderService;
        _tokenService = tokenService;
        _httpContextAccessor = httpContextAccessor;
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

    public Usuario Authenticate(string refreshToken)
    {
        var email = _tokenService.GetEmailFromRefreshToken(refreshToken);
        var usuario = _usuarioRepository.FindByEmail(email);
        if (usuario == null)
        {
            throw new InvalidCredentialsException();
        }
        return usuario;
    }

    public Usuario GetUsuarioAutenticado()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null || user.Claims == null)
        {
            throw new UnauthenticatedException();
        }
        var email = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var usuario = _usuarioRepository.FindByEmail(email ?? "");
        if (usuario == null)
        {
            throw new ModelNotFoundExceptionException("Usuário não encontrado");
        }
        return usuario;
    }
}