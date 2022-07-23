using EDiaristas.Api.Usuarios.Services;
using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Api.Common.Routes;
using Microsoft.AspNetCore.Mvc;
using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Common.Dtos;

namespace EDiaristas.Api.Usuarios.Controllers;

[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IAssembler<UsuarioResponse> _usuarioResponseAssembler;

    public UsuarioController(
        IUsuarioService usuarioService,
        IAssembler<UsuarioResponse> usuarioResponseAssembler)
    {
        _usuarioService = usuarioService;
        _usuarioResponseAssembler = usuarioResponseAssembler;
    }

    [HttpPost(
        ApiRoutes.Usuarios.CadastrarUsuario,
        Name = ApiRoutes.Usuarios.CadastrarUsuarioName)]
    public IActionResult Cadastrar([FromForm] UsuarioRequest request)
    {
        var body = _usuarioService.Cadastrar(request);
        return CreatedAtRoute(
            ApiRoutes.Me.ExibirUsuarioAutenticadoName,
            _usuarioResponseAssembler.ToResource(body, HttpContext));
    }
}