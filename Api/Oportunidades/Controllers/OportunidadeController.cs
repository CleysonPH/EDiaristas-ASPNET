using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Oportunidades.Dtos;
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
    private readonly IAssembler<OportunidadeResponse> _oportunidadeResponseAssembler;

    public OportunidadeController(
        IOportunidadeService oportunidadeService,
        IAssembler<OportunidadeResponse> oportunidadeResponseAssembler)
    {
        _oportunidadeService = oportunidadeService;
        _oportunidadeResponseAssembler = oportunidadeResponseAssembler;
    }

    [HttpGet(ApiRoutes.Oportunidade.BuscarOportunidades, Name = ApiRoutes.Oportunidade.BuscarOportunidadesName)]
    public IActionResult BuscarOportunidades()
    {
        var body = _oportunidadeService.BuscarOportunidades();
        return Ok(_oportunidadeResponseAssembler.ToResourceCollection(body, HttpContext));
    }
}