using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Pagamentos.Services;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Pagamentos.Controllers;

[ApiController]
[Authorize(Roles = Roles.Diarista, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PagamentoController : ControllerBase
{
    private readonly IPagamentoService _pagamentoService;

    public PagamentoController(IPagamentoService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    [HttpGet(ApiRoutes.Pagamentos.Listar, Name = ApiRoutes.Pagamentos.ListarName)]
    public IActionResult Listar()
    {
        var pagamentos = _pagamentoService.Listar();
        return Ok(pagamentos);
    }
}