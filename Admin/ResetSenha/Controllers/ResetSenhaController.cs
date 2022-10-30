using Microsoft.AspNetCore.Mvc;
using EDiaristas.Admin.Common.Routes;
using EDiaristas.Admin.ResetSenha.Services;
using EDiaristas.Admin.ResetSenha.Dtos;
using EDiaristas.Admin.Common.Extensions;
using EDiaristas.Admin.Common.Dtos;
using FluentValidation;
using EDiaristas.Core.Exceptions;

namespace EDiaristas.Admin.ResetSenha.Controllers;

public class ResetSenhaController : Controller
{
    private readonly IResetSenhaService _resetSenhaService;

    public ResetSenhaController(IResetSenhaService resetSenhaService)
    {
        _resetSenhaService = resetSenhaService;
    }

    [HttpGet(AdminRoutes.ResetSenha.Solicitar, Name = AdminRoutes.ResetSenha.SolicitarName)]
    public IActionResult Solicitar()
    {
        ViewData["Title"] = "Solicitar Reset de Senha";
        return View();
    }

    [HttpPost(AdminRoutes.ResetSenha.Solicitar, Name = AdminRoutes.ResetSenha.SolicitarName)]
    public IActionResult Solicitar([FromForm] SolicitarResetSenhaForm form)
    {
        try
        {
            _resetSenhaService.SolicitarResetSenha(form);
            TempData.Put("Alert", Alert.Success("Verifique seu e-mail para continuar o processo de reset de senha"));
            return RedirectToRoute(AdminRoutes.ResetSenha.SolicitarName);
        }
        catch (ValidationException e)
        {
            ViewData["Title"] = "Solicitar Reset de Senha";
            TempData.Put("Alert", Alert.Error("Houveram erros de validação"));
            e.AddErrorsToModelState(ModelState);
            return View(form);
        }
    }

    [HttpGet(AdminRoutes.ResetSenha.Resetar, Name = AdminRoutes.ResetSenha.ResetarName)]
    public IActionResult Confirmar()
    {
        ViewData["Title"] = "Confirmar Reset de Senha";
        return View();
    }

    [HttpPost(AdminRoutes.ResetSenha.Resetar, Name = AdminRoutes.ResetSenha.ResetarName)]
    public IActionResult Confirmar([FromQuery] string token, [FromForm] ConfirmarResetSenhaForm form)
    {
        try
        {
            _resetSenhaService.ConfirmarResetSenha(token, form);
            TempData.Put("Alert", Alert.Success("Senha resetada com sucesso!"));
            return RedirectToRoute(AdminRoutes.Auth.LoginName);
        }
        catch (ValidationException e)
        {
            ViewData["Title"] = "Confirmar Reset de Senha";
            TempData.Put("Alert", Alert.Error("Houveram erros de validação"));
            e.AddErrorsToModelState(ModelState);
            return View(form);
        }
        catch (PasswordResetTokenNotFoundException)
        {
            TempData.Put("Alert", Alert.Error("Token inválido"));
            return RedirectToRoute(AdminRoutes.ResetSenha.SolicitarName);
        }
        catch (PasswordResetTokenExpiredException)
        {
            TempData.Put("Alert", Alert.Error("Token expirado"));
            return RedirectToRoute(AdminRoutes.ResetSenha.SolicitarName);
        }
        catch (UsuarioNotFoundException)
        {
            TempData.Put("Alert", Alert.Error("Usuário associado ao token não encontrado"));
            return RedirectToRoute(AdminRoutes.ResetSenha.SolicitarName);
        }
    }
}