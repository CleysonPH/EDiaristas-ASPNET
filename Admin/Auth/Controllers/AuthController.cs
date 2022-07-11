using EDiaristas.Admin.Auth.Dtos;
using EDiaristas.Admin.Auth.Services;
using EDiaristas.Admin.Common.Dtos;
using EDiaristas.Admin.Common.Extensions;
using EDiaristas.Admin.Servicos.Controllers;
using EDiaristas.Admin.Auth.Routes;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Admin.Auth.Controllers;

[Authorize(Roles = Roles.Admin, AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpGet(AuthRoutes.Login)]
    public IActionResult Login()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost(AuthRoutes.Login)]
    [ValidateAntiForgeryToken]
    public IActionResult Login([FromForm] LoginForm form, [FromQuery] string returnUrl)
    {
        try
        {
            _authService.Login(form, HttpContext);
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction(nameof(ServicoController.Index), nameof(ServicoController).Replace("Controller", ""));
            }
            return Redirect(returnUrl);
        }
        catch (ValidationException e)
        {
            TempData.Put("Alert", Alert.Error("Houveram erros de validação"));
            e.AddErrorsToModelState(ModelState);
            return View(form);
        }
        catch (InvalidCredentialsException e)
        {
            TempData.Put("Alert", Alert.Error(e.Message));
            return View(form);
        }
    }

    [HttpGet(AuthRoutes.Logout)]
    public IActionResult Logout()
    {
        _authService.Logout(HttpContext);
        return RedirectToAction(nameof(Login));
    }
}