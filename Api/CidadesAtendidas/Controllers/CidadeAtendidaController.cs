using EDiaristas.Api.CidadesAtentidas.Dtos;
using EDiaristas.Api.CidadesAtentidas.Services;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.CidadesAtentidas.Cotrollers;

[ApiController]
[Authorize(
    Roles = Roles.Diarista,
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CidadeAtendidaController : ControllerBase
{
    private readonly ICidadeAtendidaService _cidadeAtendidaService;

    public CidadeAtendidaController(ICidadeAtendidaService cidadeAtendidaService)
    {
        _cidadeAtendidaService = cidadeAtendidaService;
    }

    [HttpGet(ApiRoutes.CidadeAtendida.ListarPorUsuarioLogado, Name = ApiRoutes.CidadeAtendida.ListarPorUsuarioLogadoName)]
    public IActionResult ListarPorUsuarioLogado()
    {
        var body = _cidadeAtendidaService.ListarPorUsuarioLogado();
        return Ok(body);
    }

    [HttpPut(ApiRoutes.CidadeAtendida.Atualizar, Name = ApiRoutes.CidadeAtendida.AtualizarName)]
    public IActionResult Atualizar([FromBody] CidadesAtendidasRequest request)
    {
        var body = _cidadeAtendidaService.Atualizar(request);
        return Ok(body);
    }
}