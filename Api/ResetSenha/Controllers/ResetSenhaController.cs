using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.ResetSenha.Dtos;
using EDiaristas.Api.ResetSenha.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.ResetSenha.Controllers;

[ApiController]
public class ResetSenhaController : ControllerBase
{
    private readonly IResetSenhaService _resetSenhaService;

    public ResetSenhaController(IResetSenhaService resetSenhaService)
    {
        _resetSenhaService = resetSenhaService;
    }

    [HttpPost(ApiRoutes.ResetSenha.SolicitarResetSenha, Name = ApiRoutes.ResetSenha.SolicitarResetSenhaName)]
    public IActionResult SolicitarResetSenha([FromBody] SolicitarResetSenhaRequest request)
    {
        var response = _resetSenhaService.SolicitarResetSenha(request);
        return Ok(response);
    }

    [HttpPost(ApiRoutes.ResetSenha.ConfirmaResetSenha, Name = ApiRoutes.ResetSenha.ConfirmaResetSenhaName)]
    public IActionResult ConfirmaResetSenha([FromBody] ConfirmaResetSenhaRequest request)
    {
        var response = _resetSenhaService.ConfirmaResetSenha(request);
        return Ok(response);
    }
}