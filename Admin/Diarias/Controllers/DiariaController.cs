using EDiaristas.Admin.Diarias.Services;
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

    public IActionResult Index()
    {
        ViewData["Title"] = "Listagem de Diárias";
        return View(_diariaService.Listar());
    }
}