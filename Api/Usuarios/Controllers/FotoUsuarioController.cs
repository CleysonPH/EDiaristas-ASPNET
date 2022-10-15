using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EDiaristas.Api.Usuarios.Services;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Usuarios.Dtos;

namespace EDiaristas.Api.Usuarios.Controllers;

[ApiController]
[Authorize(
    Roles = $"{Roles.Cliente},{Roles.Diarista}",
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class FotoUsuarioController : ControllerBase
{
    private readonly IFotoUsuarioService _fotoUsuarioService;

    public FotoUsuarioController(IFotoUsuarioService fotoUsuarioService)
    {
        _fotoUsuarioService = fotoUsuarioService;
    }

    [HttpPost(ApiRoutes.Usuarios.AtualizarFotoUsuario, Name = ApiRoutes.Usuarios.AtualizarFotoUsuarioName)]
    public IActionResult AtualizarFotoUsuario([FromForm] AtualizarFotoRequest atualizarFotoRequest)
    {
        ModelState.Clear();
        var body = _fotoUsuarioService.AtualizarFotoUsuario(atualizarFotoRequest);
        return Ok(body);
    }
}