using EDiaristas.Api.Servicos.Services;
using EDiaristas.Api.Servicos.Routes;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Servicos.Controllers;

[ApiController]
public class ServicoController : ControllerBase
{
    private readonly IServicoService _servicoService;

    public ServicoController(IServicoService servicoService)
    {
        _servicoService = servicoService;
    }

    [HttpGet(ServicoRoutes.FindAll)]
    public IActionResult FindAll()
    {
        return Ok(_servicoService.FindAll());
    }
}