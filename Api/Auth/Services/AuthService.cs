using EDiaristas.Api.Auth.Dtos;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Core.Models;
using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.Token.Adapters;
using FluentValidation;

namespace EDiaristas.Api.Auth.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IValidator<LoginRequest> _loginRequestValidator;
    private readonly ICustomAuthenticationService _authenticationService;
    private readonly IValidator<RefreshTokenRequest> _refreshTokenRequestValidator;

    public AuthService(
        ITokenService tokenService,
        IValidator<LoginRequest> loginRequestValidator,
        ICustomAuthenticationService authenticationService,
        IValidator<RefreshTokenRequest> refreshTokenRequestValidator)
    {
        _tokenService = tokenService;
        _loginRequestValidator = loginRequestValidator;
        _authenticationService = authenticationService;
        _refreshTokenRequestValidator = refreshTokenRequestValidator;
    }

    public TokenResponse RefreshToken(RefreshTokenRequest request)
    {
        _refreshTokenRequestValidator.ValidateAndThrow(request);
        var usuario = _authenticationService.Authenticate(request.Refresh);
        return generateTokenResponse(usuario);
    }

    public TokenResponse Token(LoginRequest request)
    {
        _loginRequestValidator.ValidateAndThrow(request);
        var usuario = _authenticationService.Authenticate(request.Email, request.Password);
        return generateTokenResponse(usuario);
    }

    private TokenResponse generateTokenResponse(Usuario usuario)
    {
        return new TokenResponse
        {
            Access = _tokenService.GenerateAccessToken(usuario),
            Refresh = _tokenService.GenerateRefreshToken(usuario)
        };
    }
}