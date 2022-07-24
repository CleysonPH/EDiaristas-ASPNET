using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Api.Diarias.Services;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Diarias.Controllers;

[ApiController]
public class DiariaController : ControllerBase
{
    private readonly IDiariaService _diariaService;

    public DiariaController(IDiariaService diariaService)
    {
        _diariaService = diariaService;
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
}