using EDiaristas.Admin.Auth.Dtos;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Usuarios;
using FluentValidation;
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

    public void Login(LoginForm form)
    {
        _loginFormValidator.ValidateAndThrow(form);
        var result = _signInManager.PasswordSignInAsync(form.Email, form.Senha, form.LembrarMe, false)
            .GetAwaiter()
            .GetResult();
        if (!result.Succeeded)
        {
            throw new InvalidCredentialsException();
        }
    }

    public void Logout()
    {
        _signInManager.SignOutAsync().GetAwaiter().GetResult();
    }
}