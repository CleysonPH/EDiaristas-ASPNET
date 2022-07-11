using EDiaristas.Api.Auth.Dtos;
using EDiaristas.Api.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Auth.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("/api/auth/token")]
    public IActionResult Token([FromBody] LoginRequest request)
    {
        return Ok(_authService.Token(request));
    }
}