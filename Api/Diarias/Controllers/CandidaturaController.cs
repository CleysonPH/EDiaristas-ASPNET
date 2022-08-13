using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Diarias.Services;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Diarias.Controllers;

[ApiController]
[Authorize(
    Roles = Roles.Diarista,
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)
]
public class CandidaturaController : ControllerBase
{
    private readonly ICandidaturaService _candidaturaService;

    public CandidaturaController(ICandidaturaService candidaturaService)
    {
        _candidaturaService = candidaturaService;
    }

    [HttpPost(ApiRoutes.Diarias.Candidatar, Name = ApiRoutes.Diarias.CandidatarName)]
    public IActionResult Candidatar([FromRoute] int diariaId)
    {
        var body = _candidaturaService.Candidatar(diariaId);
        return Ok(body);
    }
}