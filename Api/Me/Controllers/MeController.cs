using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Me.Services;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Me.Controllers;

[ApiController]
[Authorize(
    Roles = $"{Roles.Cliente}, {Roles.Diarista}",
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class MeController : ControllerBase
{
    private readonly IMeService _meService;
    private readonly IAssembler<UsuarioResponse> _usuarioResponseAssembler;

    public MeController(
        IMeService meService,
        IAssembler<UsuarioResponse> usuarioResponseAssembler)
    {
        _meService = meService;
        _usuarioResponseAssembler = usuarioResponseAssembler;
    }

    [HttpGet(
        ApiRoutes.Me.ExibirUsuarioAutenticado,
        Name = ApiRoutes.Me.ExibirUsuarioAutenticadoName)]
    public IActionResult ExibirUsuarioAutenticado()
    {
        var body = _meService.ExibirUsuarioAutenticado();
        return Ok(_usuarioResponseAssembler.ToResource(body, HttpContext));
    }
}