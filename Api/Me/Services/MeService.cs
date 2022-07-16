using EDiaristas.Api.Me.Dtos;
using EDiaristas.Api.Me.Mappers;
using EDiaristas.Core.Services.Authentication.Adapters;

namespace EDiaristas.Api.Me.Services;

public class MeService : IMeService
{
    private readonly ICustomAuthenticationService _authenticationService;
    private readonly IMeMapper _meMapper;

    public MeService(ICustomAuthenticationService authenticationService, IMeMapper meMapper)
    {
        _authenticationService = authenticationService;
        _meMapper = meMapper;
    }

    public MeResponse ExibirUsuarioAutenticado()
    {
        var usuario = _authenticationService.GetUsuarioAutenticado();
        return _meMapper.ToResponse(usuario);
    }
}