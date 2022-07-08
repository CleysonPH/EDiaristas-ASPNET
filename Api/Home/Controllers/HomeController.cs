using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Home.Dtos;
using EDiaristas.Api.Home.Routes;
using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Home.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    private readonly IAssembler<HomeResponse> _homeAssembler;

    public HomeController(IAssembler<HomeResponse> homeAssembler)
    {
        _homeAssembler = homeAssembler;
    }

    [HttpGet(HomeRoutes.Home, Name = HomeRoutes.HomeName)]
    public IActionResult Home()
    {
        return Ok(_homeAssembler.ToResource(new HomeResponse(), HttpContext));
    }
}