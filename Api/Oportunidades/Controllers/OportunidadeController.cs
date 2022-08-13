using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Oportunidades.Services;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Oportunidades.Controllers;

[ApiController]
[Authorize(
    Roles = Roles.Diarista,
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class OportunidadeController : ControllerBase
{
    private readonly IOportunidadeService _oportunidadeService;

    public OportunidadeController(IOportunidadeService oportunidadeService)
    {
        _oportunidadeService = oportunidadeService;
    }

    [HttpGet(ApiRoutes.Oportunidade.BuscarOportunidades, Name = ApiRoutes.Oportunidade.BuscarOportunidadesName)]
    public IActionResult BuscarOportunidades()
    {
        var oportunidades = _oportunidadeService.BuscarOportunidades();
        return Ok(oportunidades);
    }
}