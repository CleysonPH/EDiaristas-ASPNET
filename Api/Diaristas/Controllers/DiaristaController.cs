using EDiaristas.Api.Diaristas.Services;
using EDiaristas.Api.Common.Routes;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Diaristas.Controllers;

[ApiController]
public class DiaristaController : ControllerBase
{
    private readonly IDiaristaService _diaristaService;

    public DiaristaController(IDiaristaService diaristaService)
    {
        _diaristaService = diaristaService;
    }

    [HttpGet(
        ApiRoutes.Diaristas.BuscarDiaristasPorCep,
        Name = ApiRoutes.Diaristas.BuscarDiaristasPorCepName)]
    public IActionResult FindByCep(string cep)
    {
        return Ok(_diaristaService.FindByCep(cep));
    }

    [HttpGet(
        ApiRoutes.Diaristas.VerificarDisponibilidadePorCep,
        Name = ApiRoutes.Diaristas.VerificarDisponibilidadePorCepName)]
    public IActionResult VerificarDisponibilidadePorCep(string cep)
    {
        return Ok(_diaristaService.VerificarDisponibilidadePorCep(cep));
    }
}