using EDiaristas.Api.Auth.Dtos;
using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.Token.Adapters;
using FluentValidation;

namespace EDiaristas.Api.Auth.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IValidator<LoginRequest> _loginRequestValidator;
    private readonly ICustomAuthenticationService _authenticationService;

    public AuthService(
        ITokenService tokenService,
        IValidator<LoginRequest> loginRequestValidator,
        ICustomAuthenticationService authenticationService)
    {
        _tokenService = tokenService;
        _loginRequestValidator = loginRequestValidator;
        _authenticationService = authenticationService;
    }

    public TokenResponse Token(LoginRequest request)
    {
        _loginRequestValidator.ValidateAndThrow(request);
        var usuario = _authenticationService.Authenticate(request.Email, request.Password);
        return new TokenResponse
        {
            Access = _tokenService.GenerateAccessToken(usuario)
        };
    }
}