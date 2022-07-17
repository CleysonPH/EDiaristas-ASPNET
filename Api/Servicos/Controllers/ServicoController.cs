using EDiaristas.Api.Servicos.Services;
using EDiaristas.Api.Common.Routes;
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

    [HttpGet(ApiRoutes.Servicos.FindAll, Name = ApiRoutes.Servicos.FindAllName)]
    public IActionResult FindAll()
    {
        return Ok(_servicoService.FindAll());
    }
}