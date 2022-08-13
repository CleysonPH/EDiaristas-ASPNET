using EDiaristas.Api.Oportunidades.Dtos;
using EDiaristas.Api.Oportunidades.Mappers;
using EDiaristas.Core.Repositories.Diarias;
using EDiaristas.Core.Services.Authentication.Adapters;

namespace EDiaristas.Api.Oportunidades.Services;

public class OportunidadeService : IOportunidadeService
{
    private readonly IDiariaRepository _diariaRepository;
    private readonly IOportunidadeMapper _oportunidadeMapper;
    private readonly ICustomAuthenticationService _authenticationService;

    public OportunidadeService(
        IDiariaRepository diariaRepository,
        IOportunidadeMapper oportunidadeMapper,
        ICustomAuthenticationService authenticationService)
    {
        _diariaRepository = diariaRepository;
        _oportunidadeMapper = oportunidadeMapper;
        _authenticationService = authenticationService;
    }

    public ICollection<OportunidadeResponse> BuscarOportunidades()
    {
        var usuarioAutenticado = _authenticationService.GetUsuarioAutenticado();
        var cidades = usuarioAutenticado.CidadesAtendidas
            .Select(c => c.CodigoIbge)
            .ToList();
        return _diariaRepository.FindOportunidades(cidades, usuarioAutenticado)
            .Select(d => _oportunidadeMapper.ToResponse(d))
            .ToList();
    }
}