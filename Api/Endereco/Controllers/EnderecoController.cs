using EDiaristas.Core.Services.ConsultaEndereco.Adapters;
using EDiaristas.Api.Enderecos.Routes;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Enderecos.Controllers;

[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly IConsultaEnderecoService _consultaEnderecoService;

    public EnderecoController(IConsultaEnderecoService consultaEnderecoService)
    {
        _consultaEnderecoService = consultaEnderecoService;
    }

    [HttpGet(EnderecoRoutes.BuscarEnderecoPorCep)]
    public IActionResult BuscarEnderecoPorCep(string cep)
    {
        return Ok(_consultaEnderecoService.FindEnderecoByCep(cep));
    }
}