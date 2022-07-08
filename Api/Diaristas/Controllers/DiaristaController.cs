using EDiaristas.Api.Diaristas.Services;
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

    [HttpGet("api/diaristas/localidades")]
    public IActionResult FindByCep(string cep)
    {
        return Ok(_diaristaService.FindByCep(cep));
    }
}