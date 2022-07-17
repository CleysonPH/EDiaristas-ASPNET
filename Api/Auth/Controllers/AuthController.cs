using EDiaristas.Api.Auth.Dtos;
using EDiaristas.Api.Auth.Services;
using EDiaristas.Api.Common.Routes;
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

    [HttpPost(ApiRoutes.Auth.Token, Name = ApiRoutes.Auth.TokenName)]
    public IActionResult Token([FromBody] LoginRequest request)
    {
        return Ok(_authService.Token(request));
    }

    [HttpPost(ApiRoutes.Auth.Refresh, Name = ApiRoutes.Auth.RefreshName)]
    public IActionResult Refresh([FromBody] RefreshTokenRequest request)
    {
        return Ok(_authService.RefreshToken(request));
    }

    [HttpPost(ApiRoutes.Auth.Logout, Name = ApiRoutes.Auth.LogoutName)]
    public IActionResult Logout([FromBody] RefreshTokenRequest request)
    {
        _authService.Logout(request);
        return StatusCode(StatusCodes.Status205ResetContent);
    }
}