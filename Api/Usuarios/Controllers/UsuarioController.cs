using EDiaristas.Api.Usuarios.Services;
using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EDiaristas.Api.Usuarios.Controllers;

[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost(
        ApiRoutes.Usuarios.CadastrarUsuario,
        Name = ApiRoutes.Usuarios.CadastrarUsuarioName)]
    public IActionResult Cadastrar([FromForm] UsuarioRequest request)
    {
        var usuario = _usuarioService.Cadastrar(request);
        return Ok(usuario);
    }

    [Authorize(Roles = $"{Roles.Cliente},{Roles.Diarista}", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("/api/usuarios/teste")]
    public IActionResult Teste()
    {
        return Ok("Teste");
    }
}