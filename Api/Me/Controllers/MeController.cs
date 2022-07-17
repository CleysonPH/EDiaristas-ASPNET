using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Me.Services;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Me.Controllers;

[Authorize(
    Roles = $"{Roles.Cliente}, {Roles.Diarista}",
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class MeController : ControllerBase
{
    private readonly IMeService _meService;

    public MeController(IMeService meService)
    {
        _meService = meService;
    }

    [HttpGet(
        ApiRoutes.Me.ExibirUsuarioAutenticado,
        Name = ApiRoutes.Me.ExibirUsuarioAutenticadoName)]
    public IActionResult ExibirUsuarioAutenticado()
    {
        var teste = HttpContext;
        return Ok(_meService.ExibirUsuarioAutenticado());
    }
}