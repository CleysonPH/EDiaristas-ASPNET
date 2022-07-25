using EDiaristas.Api.CidadesAtentidas.Dtos;
using EDiaristas.Api.CidadesAtentidas.Mappers;
using EDiaristas.Core.Services.Authentication.Adapters;

namespace EDiaristas.Api.CidadesAtentidas.Services;

public class CidadeAtendidaService : ICidadeAtendidaService
{
    private readonly ICidadeAtendidaMapper _cidadeAtendidaMapper;
    private readonly ICustomAuthenticationService _authenticationService;

    public CidadeAtendidaService(
        ICidadeAtendidaMapper cidadeAtendidaMapper,
        ICustomAuthenticationService authenticationService)
    {
        _cidadeAtendidaMapper = cidadeAtendidaMapper;
        _authenticationService = authenticationService;
    }

    public ICollection<CidadeAtendidaResponse> ListarPorUsuarioLogado()
    {
        var usuarioLogado = _authenticationService.GetUsuarioAutenticado();
        return usuarioLogado.CidadesAtendidas
            .Select(_cidadeAtendidaMapper.ToResponse)
            .ToList();
    }
}