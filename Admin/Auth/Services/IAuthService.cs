using EDiaristas.Admin.Auth.Dtos;

namespace EDiaristas.Admin.Auth.Services;

public interface IAuthService
{
    void Login(LoginForm form, HttpContext httpContext);
    void Logout(HttpContext httpContext);
}