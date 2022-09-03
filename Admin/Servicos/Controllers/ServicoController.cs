using EDiaristas.Admin.Servicos.Dtos;
using EDiaristas.Admin.Servicos.Services;
using EDiaristas.Admin.Common.Extensions;
using EDiaristas.Admin.Common.Routes;
using Microsoft.AspNetCore.Mvc;
using EDiaristas.Admin.Common.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EDiaristas.Admin.Servicos.Controllers;

[Authorize(
    Roles = Roles.Admin,
    AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
public class ServicoController : Controller
{
    private readonly IServicoService _servicoService;

    public ServicoController(IServicoService servicoService)
    {
        _servicoService = servicoService;
    }

    [HttpGet(AdminRoutes.Servicos.Index, Name = AdminRoutes.Servicos.IndexName)]
    public IActionResult Index()
    {
        ViewData["Title"] = "Lista de Serviços";
        return View(_servicoService.FindAll());
    }

    [HttpGet(AdminRoutes.Servicos.Create, Name = AdminRoutes.Servicos.CreateName)]
    public IActionResult Create()
    {
        ViewData["Title"] = "Cadastrar Serviço";
        return View("Form");
    }

    [ValidateAntiForgeryToken]
    [HttpPost(AdminRoutes.Servicos.Create, Name = AdminRoutes.Servicos.CreateName)]
    public IActionResult Create([FromForm] ServicoForm form)
    {
        try
        {
            _servicoService.Create(form);
            TempData.Put("Alert", Alert.Success("Serviço cadastrado com sucesso!"));
            return RedirectToAction(nameof(Index));
        }
        catch (ValidationException e)
        {
            ViewData["Title"] = "Cadastrar Serviço";
            TempData.Put("Alert", Alert.Error("Houveram erros de validação"));
            e.AddErrorsToModelState(ModelState);
            return View("Form", form);
        }
    }

    [HttpGet(AdminRoutes.Servicos.UpdateById, Name = AdminRoutes.Servicos.UpdateByIdName)]
    public IActionResult UpdateById([FromRoute] int id)
    {
        ViewData["Title"] = "Editar Serviço";
        return View("Form", _servicoService.FindById(id));
    }

    [ValidateAntiForgeryToken]
    [HttpPost(AdminRoutes.Servicos.UpdateById, Name = AdminRoutes.Servicos.UpdateByIdName)]
    public IActionResult UpdateById([FromRoute] int id, [FromForm] ServicoForm form)
    {
        try
        {
            _servicoService.UpdateById(id, form);
            TempData.Put("Alert", Alert.Success("Serviço atualizado com sucesso!"));
            return RedirectToAction(nameof(Index));
        }
        catch (ValidationException e)
        {
            ViewData["Title"] = "Editar Serviço";
            TempData.Put("Alert", Alert.Error("Houveram erros de validação"));
            e.AddErrorsToModelState(ModelState);
            return View("Form", form);
        }
    }

    [HttpGet(AdminRoutes.Servicos.DeleteById, Name = AdminRoutes.Servicos.DeleteByIdName)]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _servicoService.DeleteById(id);
        TempData.Put("Alert", Alert.Success("Serviço excluído com sucesso!"));
        return RedirectToAction(nameof(Index));
    }
}