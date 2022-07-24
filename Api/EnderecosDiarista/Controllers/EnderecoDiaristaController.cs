using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.EnderecosDiarista.Dtos;
using EDiaristas.Api.EnderecosDiarista.Services;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.EnderecosDiarista.Controllers;

[Authorize(
    Roles = Roles.Diarista,
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class EnderecoDiaristaController : ControllerBase
{
    private readonly IEnderecoDiaristaService _enderecoDiaristaService;

    public EnderecoDiaristaController(IEnderecoDiaristaService enderecoDiaristaService)
    {
        _enderecoDiaristaService = enderecoDiaristaService;
    }

    [HttpPut(ApiRoutes.EnderecosDiarista.AtualizarEndereco, Name = ApiRoutes.EnderecosDiarista.AtualizarEnderecoName)]
    public IActionResult AlterarEndereco([FromBody] EnderecoDiaristaRequest request)
    {
        var enderecoDiarista = _enderecoDiaristaService.AlterarEndereco(request);
        return Ok(enderecoDiarista);
    }

    [HttpGet(ApiRoutes.EnderecosDiarista.ObterEnderecoUsuarioLogado, Name = ApiRoutes.EnderecosDiarista.ObterEnderecoUsuarioLogadoName)]
    public IActionResult ObterEnderecoUsuarioLogado()
    {
        var enderecoDiarista = _enderecoDiaristaService.ObterEnderecoUsuarioLogado();
        return Ok(enderecoDiarista);
    }
}