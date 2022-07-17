using System.Security.Claims;
using EDiaristas.Admin.Auth.Dtos;
using EDiaristas.Core.Models;
using EDiaristas.Core.Services.Authentication.Adapters;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EDiaristas.Admin.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IValidator<LoginForm> _loginFormValidator;
    private readonly ICustomAuthenticationService _authenticationService;

    public AuthService(
        IValidator<LoginForm> loginFormValidator,
        ICustomAuthenticationService authenticationService)
    {
        _loginFormValidator = loginFormValidator;
        _authenticationService = authenticationService;
    }

    public void Login(LoginForm form, HttpContext httpContext)
    {
        _loginFormValidator.ValidateAndThrow(form);
        var usuario = _authenticationService.Authenticate(form.Email, form.Senha);
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Email));
        identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Email));
        identity.AddClaim(new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToTipoUsuarioName()));
        var principal = new ClaimsPrincipal(identity);
        httpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties
            {
                IsPersistent = form.LembrarMe
            }
        ).Wait();
    }

    public void Logout(HttpContext httpContext)
    {
        httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
    }
}