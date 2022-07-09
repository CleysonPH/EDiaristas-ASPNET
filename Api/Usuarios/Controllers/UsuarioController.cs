using EDiaristas.Api.Usuarios.Services;
using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Api.Usuarios.Routes;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Usuarios.Controllers;

[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost(UsuarioRoutes.CadastrarUsuario, Name = UsuarioRoutes.CadastrarUsuarioName)]
    public IActionResult Cadastrar([FromForm] UsuarioRequest request)
    {
        var usuario = _usuarioService.Cadastrar(request);
        return Ok(usuario);
    }
}