using EDiaristas.Admin.Common.Dtos;
using EDiaristas.Admin.Common.Extensions;
using EDiaristas.Admin.Common.Routes;
using EDiaristas.Admin.Diarias.Services;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Admin.Diarias.Controllers;

[Authorize(Roles = Roles.Admin, AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
public class DiariaController : Controller
{
    private readonly IDiariaService _diariaService;

    public DiariaController(IDiariaService diariaService)
    {
        _diariaService = diariaService;
    }

    [HttpGet(AdminRoutes.Diarias.Index, Name = AdminRoutes.Diarias.IndexName)]
    public IActionResult Index(
        string clienteNome = "",
        string status = "")
    {
        ViewData["Title"] = "Listagem de Diárias";
        return View(_diariaService.Listar(clienteNome, status));
    }

    [HttpGet(AdminRoutes.Diarias.MarcarComoTransferida, Name = AdminRoutes.Diarias.MarcarComoTransferidaName)]
    public IActionResult MarcarComoTransferida(int diariaId)
    {
        try
        {
            _diariaService.MarcarComoTransferida(diariaId);
            TempData.Put("Alert", Alert.Success("Diária marcada como transferida com sucesso!"));
            return RedirectToAction(nameof(Index));
        }
        catch (DiariaNotFoundException)
        {
            TempData.Put("Alert", Alert.Error("Diária não encontrada"));
            return RedirectToAction(nameof(Index));
        }
    }
}