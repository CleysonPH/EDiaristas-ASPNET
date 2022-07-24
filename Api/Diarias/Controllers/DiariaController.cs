using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Api.Diarias.Services;
using EDiaristas.Core.Models;
using EDiaristas.Core.Permissions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Diarias.Controllers;

[ApiController]
public class DiariaController : ControllerBase
{
    private readonly IDiariaService _diariaService;
    private readonly DiariaPermissions _diariaPermissions;
    private readonly IAssembler<DiariaResponse> _diariaResponseAssembler;

    public DiariaController(
        IDiariaService diariaService,
        DiariaPermissions diariaPermissions,
        IAssembler<DiariaResponse> diariaResponseAssembler)
    {
        _diariaService = diariaService;
        _diariaPermissions = diariaPermissions;
        _diariaResponseAssembler = diariaResponseAssembler;
    }

    [Authorize(
        Roles = Roles.Cliente,
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)
    ]
    [HttpPost(ApiRoutes.Diarias.Cadastrar, Name = ApiRoutes.Diarias.CadastrarName)]
    public IActionResult Cadastrar([FromBody] DiariaRequest request)
    {
        var body = _diariaService.Cadastrar(request);
        return Created("", _diariaResponseAssembler.ToResource(body, HttpContext));
    }

    [Authorize(
        Roles = Roles.Cliente,
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)
    ]
    [HttpPost(ApiRoutes.Diarias.Pagar, Name = ApiRoutes.Diarias.PagarName)]
    public IActionResult Pagar([FromBody] PagamentoRequest request, int diariaId)
    {
        _diariaPermissions.CheckPermission(User, diariaId, DiariaOperations.Pagar);
        var body = _diariaService.Pagar(request, diariaId);
        return Ok(body);
    }

    [Authorize(
        Roles = $"{Roles.Cliente},{Roles.Diarista}",
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)
    ]
    [HttpGet(ApiRoutes.Diarias.Listar, Name = ApiRoutes.Diarias.ListarName)]
    public IActionResult Listar()
    {
        var body = _diariaService.ListarPeloUsuarioLogado();
        return Ok(_diariaResponseAssembler.ToResourceCollection(body, HttpContext));
    }

    [Authorize(
        Roles = $"{Roles.Cliente},{Roles.Diarista}",
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)
    ]
    [HttpGet(ApiRoutes.Diarias.BuscarPorId, Name = ApiRoutes.Diarias.BuscarPorIdName)]
    public IActionResult BuscarPorId(int diariaId)
    {
        _diariaPermissions.CheckPermission(User, diariaId, DiariaOperations.Detalhar);
        var body = _diariaService.BuscarPeloId(diariaId);
        return Ok(_diariaResponseAssembler.ToResource(body, HttpContext));
    }
}