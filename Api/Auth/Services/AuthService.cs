using EDiaristas.Api.Auth.Dtos;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.Token.Adapters;
using FluentValidation;

namespace EDiaristas.Api.Auth.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IValidator<LoginRequest> _loginRequestValidator;

    public AuthService(
        ITokenService tokenService,
        IUsuarioRepository usuarioRepository,
        IValidator<LoginRequest> loginRequestValidator)
    {
        _tokenService = tokenService;
        _usuarioRepository = usuarioRepository;
        _loginRequestValidator = loginRequestValidator;
    }

    public TokenResponse Token(LoginRequest request)
    {
        _loginRequestValidator.ValidateAndThrow(request);
        var user = _usuarioRepository.FindByEmail(request.Email);
        if (user == null)
        {
            throw new InvalidCredentialsException();
        }
        if (!_usuarioRepository.CheckPassword(request.Email, request.Password))
        {
            throw new InvalidCredentialsException();
        }

        return new TokenResponse
        {
            Access = _tokenService.GenerateAccessToken(user)
        };
    }
}