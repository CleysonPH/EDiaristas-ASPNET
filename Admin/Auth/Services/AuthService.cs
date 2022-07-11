using System.Security.Claims;
using EDiaristas.Admin.Auth.Dtos;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Usuarios;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace EDiaristas.Admin.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly IValidator<LoginForm> _loginFormValidator;

    public AuthService(
        IUsuarioRepository usuarioRepository,
        SignInManager<Usuario> signInManager,
        IValidator<LoginForm> loginFormValidator)
    {
        _usuarioRepository = usuarioRepository;
        _signInManager = signInManager;
        _loginFormValidator = loginFormValidator;
    }

    public void Login(LoginForm form, HttpContext httpContext)
    {
        _loginFormValidator.ValidateAndThrow(form);
        var usuario = _usuarioRepository.FindByEmail(form.Email);
        if (usuario == null)
        {
            throw new InvalidCredentialsException();
        }
        if (!_usuarioRepository.CheckPassword(form.Email, form.Senha))
        {
            throw new InvalidCredentialsException();
        }
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.UserName));
        identity.AddClaim(new Claim(ClaimTypes.Name, usuario.UserName));
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