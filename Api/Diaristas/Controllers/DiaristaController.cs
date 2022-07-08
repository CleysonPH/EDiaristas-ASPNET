using EDiaristas.Api.Diaristas.Services;
using EDiaristas.Api.Diaristas.Routes;
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

    [HttpGet(DiaristaRoutes.BuscarDiaristasPorCep)]
    public IActionResult FindByCep(string cep)
    {
        return Ok(_diaristaService.FindByCep(cep));
    }
}