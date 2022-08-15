using EDiaristas.Api.Avaliacoes.Dtos;
using EDiaristas.Api.Avaliacoes.Services;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Core.Models;
using EDiaristas.Core.Permissions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Avaliacoes.Controllers;

[ApiController]
[Authorize(
    Roles = $"{Roles.Cliente}, {Roles.Diarista}",
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AvaliacaoController : ControllerBase
{
    private readonly IAvaliacaoService _avaliacaoService;
    private readonly DiariaPermissions _diariaPermissions;

    public AvaliacaoController(
        IAvaliacaoService avaliacaoService,
        DiariaPermissions diariaPermissions)
    {
        _avaliacaoService = avaliacaoService;
        _diariaPermissions = diariaPermissions;
    }

    [HttpPatch(ApiRoutes.Avaliacao.Avaliar, Name = ApiRoutes.Avaliacao.AvaliarName)]
    public ActionResult Avaliar([FromBody] AvaliacaoRequest request, [FromRoute] int diariaId)
    {
        _diariaPermissions.CheckPermission(User, diariaId, DiariaOperations.Avaliar);
        var response = _avaliacaoService.Avaliar(request, diariaId);
        return Ok(response);
    }
}