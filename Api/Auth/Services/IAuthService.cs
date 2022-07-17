using EDiaristas.Api.Auth.Dtos;
using EDiaristas.Api.Common.Dtos;

namespace EDiaristas.Api.Auth.Services;

public interface IAuthService
{
    TokenResponse Token(LoginRequest request);
    TokenResponse RefreshToken(RefreshTokenRequest request);
    void Logout(RefreshTokenRequest request);
}