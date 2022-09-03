using EDiaristas.Admin.Common.Dtos;
using EDiaristas.Admin.Common.Extensions;
using EDiaristas.Admin.Common.Routes;
using EDiaristas.Admin.Usuarios.Dtos;
using EDiaristas.Admin.Usuarios.Services;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Admin.Usuarios.Controllers;

[Authorize(Roles = Roles.Admin, AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
public class UsuarioController : Controller
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet(AdminRoutes.Usuarios.Index, Name = AdminRoutes.Usuarios.IndexName)]
    public IActionResult Index()
    {
        ViewData["Title"] = "Lista de Usuários";
        return View(_usuarioService.FindAll());
    }

    [HttpGet(AdminRoutes.Usuarios.Create, Name = AdminRoutes.Usuarios.CreateName)]
    public IActionResult Create()
    {
        ViewData["Title"] = "Cadastrar Usuário";
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost(AdminRoutes.Usuarios.Create, Name = AdminRoutes.Usuarios.CreateName)]
    public IActionResult Create([FromForm] UsuarioCreateForm form)
    {
        try
        {
            _usuarioService.Create(form);
            TempData.Put("Alert", Alert.Success("Usuário cadastrado com sucesso!"));
            return RedirectToAction(nameof(Index));
        }
        catch (ValidationException e)
        {
            ViewData["Title"] = "Cadastrar Usuário";
            TempData.Put("Alert", Alert.Error("Houveram erros de validação"));
            e.AddErrorsToModelState(ModelState);
            return View(form);
        }
    }

    [HttpGet(AdminRoutes.Usuarios.UpdateById, Name = AdminRoutes.Usuarios.UpdateByIdName)]
    public IActionResult UpdateById([FromRoute] int id)
    {
        ViewData["Title"] = "Editar Usuário";
        return View(_usuarioService.FindById(id));
    }

    [ValidateAntiForgeryToken]
    [HttpPost(AdminRoutes.Usuarios.UpdateById, Name = AdminRoutes.Usuarios.UpdateByIdName)]
    public IActionResult UpdateById([FromRoute] int id, [FromForm] UsuarioUpdateForm form)
    {
        try
        {
            _usuarioService.UpdateById(id, form);
            TempData.Put("Alert", Alert.Success("Usuário atualizado com sucesso!"));
            return RedirectToAction(nameof(Index));
        }
        catch (ValidationException e)
        {
            ViewData["Title"] = "Editar Usuário";
            TempData.Put("Alert", Alert.Error("Houveram erros de validação"));
            e.AddErrorsToModelState(ModelState);
            return View(form);
        }
    }

    [HttpGet(AdminRoutes.Usuarios.DeleteById, Name = AdminRoutes.Usuarios.DeleteByIdName)]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _usuarioService.DeleteById(id);
        TempData.Put("Alert", Alert.Success("Usuário excluído com sucesso!"));
        return RedirectToAction(nameof(Index));
    }

    [HttpGet(AdminRoutes.Usuarios.UpdatePassword, Name = AdminRoutes.Usuarios.UpdatePasswordName)]
    public IActionResult UpdatePassword()
    {
        ViewData["Title"] = "Alterar Senha";
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost(AdminRoutes.Usuarios.UpdatePassword, Name = AdminRoutes.Usuarios.UpdatePasswordName)]
    public IActionResult UpdatePassword([FromForm] UpdatePasswordForm form)
    {
        try
        {
            _usuarioService.UpdatePassword(User.Identity?.Name ?? "", form);
            TempData.Put("Alert", Alert.Success("Senha atualizada com sucesso!"));
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidCredentialsException)
        {
            ViewData["Title"] = "Alterar Senha";
            ModelState.AddModelError("SenhaAntiga", "senha incorreta");
            return View(form);
        }
        catch (ValidationException e)
        {
            ViewData["Title"] = "Alterar Senha";
            TempData.Put("Alert", Alert.Error("Houveram erros de validação"));
            e.AddErrorsToModelState(ModelState);
            return View(form);
        }
    }

}