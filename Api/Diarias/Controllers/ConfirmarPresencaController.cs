using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Diarias.Services;
using EDiaristas.Core.Models;
using EDiaristas.Core.Permissions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Diarias.Controllers;

[ApiController]
[Authorize(
    Roles = Roles.Cliente,
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ConfirmarPresencaController : ControllerBase
{
    private readonly DiariaPermissions _diariaPermissions;
    private readonly IConfirmacaoPresencaService _confirmacaoPresencaService;

    public ConfirmarPresencaController(
        DiariaPermissions diariaPermissions,
        IConfirmacaoPresencaService confirmacaoPresencaService)
    {
        _diariaPermissions = diariaPermissions;
        _confirmacaoPresencaService = confirmacaoPresencaService;
    }

    [HttpPatch(ApiRoutes.Diarias.ConfirmarPresenca, Name = ApiRoutes.Diarias.ConfirmarPresencaName)]
    public ActionResult ConfirmarPresenca(int diariaId)
    {
        _diariaPermissions.CheckPermission(User, diariaId, DiariaOperations.ConfirmarPresenca);
        var body = _confirmacaoPresencaService.ConfirmarPresenca(diariaId);
        return Ok(body);
    }
}