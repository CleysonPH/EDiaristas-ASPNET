using EDiaristas.Admin.Common.Dtos;
using EDiaristas.Admin.Common.Extensions;
using EDiaristas.Admin.Usuarios.Dtos;
using EDiaristas.Admin.Usuarios.Routes;
using EDiaristas.Admin.Usuarios.Services;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Admin.Usuarios.Controllers;

[Authorize(Roles = Roles.Admin)]
public class UsuarioController : Controller
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet(UsuarioRoutes.Index)]
    public IActionResult Index()
    {
        ViewData["Title"] = "Lista de Usuários";
        return View(_usuarioService.FindAll());
    }

    [HttpGet(UsuarioRoutes.Create)]
    public IActionResult Create()
    {
        ViewData["Title"] = "Cadastrar Usuário";
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost(UsuarioRoutes.Create)]
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

    [HttpGet(UsuarioRoutes.UpdateById)]
    public IActionResult UpdateById([FromRoute] int id)
    {
        ViewData["Title"] = "Editar Usuário";
        return View(_usuarioService.FindById(id));
    }

    [ValidateAntiForgeryToken]
    [HttpPost(UsuarioRoutes.UpdateById)]
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

    [HttpGet(UsuarioRoutes.DeleteById)]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _usuarioService.DeleteById(id);
        TempData.Put("Alert", Alert.Success("Usuário excluído com sucesso!"));
        return RedirectToAction(nameof(Index));
    }

    [HttpGet(UsuarioRoutes.UpdatePassword)]
    public IActionResult UpdatePassword()
    {
        ViewData["Title"] = "Alterar Senha";
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost(UsuarioRoutes.UpdatePassword)]
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