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

    public DiariaController(
        IDiariaService diariaService,
        DiariaPermissions diariaPermissions)
    {
        _diariaService = diariaService;
        _diariaPermissions = diariaPermissions;
    }

    [Authorize(
        Roles = Roles.Cliente,
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)
    ]
    [HttpPost(ApiRoutes.Diarias.Cadastrar, Name = ApiRoutes.Diarias.CadastrarName)]
    public IActionResult Cadastrar([FromBody] DiariaRequest request)
    {
        return Created("", _diariaService.Cadastrar(request));
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
}