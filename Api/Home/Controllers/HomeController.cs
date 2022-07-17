using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Home.Dtos;
using EDiaristas.Api.Common.Routes;
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

    [HttpGet(ApiRoutes.Home.Index, Name = ApiRoutes.Home.IndexName)]
    public IActionResult Index()
    {
        return Ok(_homeAssembler.ToResource(new HomeResponse(), HttpContext));
    }
}