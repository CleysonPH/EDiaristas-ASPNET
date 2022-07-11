using EDiaristas.Api.Auth.Dtos;

namespace EDiaristas.Api.Auth.Services;

public interface IAuthService
{
    TokenResponse Token(LoginRequest request);
}