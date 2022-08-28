using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Api.Diarias.Services;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Core.Permissions;

namespace EDiaristas.Api.Diarias.Controllers;

[ApiController]
[Authorize(
    Roles = $"{Roles.Diarista}, {Roles.Cliente}",
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)
]
public class CancelamentoController : ControllerBase
{
    private readonly DiariaPermissions _diariaPermissions;
    private readonly ICancelamentoService _cancelamentoService;

    public CancelamentoController(
        DiariaPermissions diariaPermissions,
        ICancelamentoService cancelamentoService)
    {
        _diariaPermissions = diariaPermissions;
        _cancelamentoService = cancelamentoService;
    }

    [HttpPatch(ApiRoutes.Diarias.Cancelar, Name = ApiRoutes.Diarias.CancelarName)]
    public IActionResult Cancelar([FromRoute] int diariaId, [FromBody] CancelamentoRequest cancelamentoRequest)
    {
        _diariaPermissions.CheckPermission(User, diariaId, DiariaOperations.Cancelar);
        var body = _cancelamentoService.Cancelar(diariaId, cancelamentoRequest);
        return Ok(body);
    }
}