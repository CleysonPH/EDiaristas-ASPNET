using EDiaristas.Api.Diaristas.Dtos;
using EDiaristas.Api.Diaristas.Mappers;
using EDiaristas.Core.Repositories;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.ConsultaEndereco.Adapters;

namespace EDiaristas.Api.Diaristas.Services;

public class DiaristaService : IDiaristaService
{
    private readonly IDiaristaMapper _diaristaMapper;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConsultaEnderecoService _consultaEnderecoService;

    public DiaristaService(
        IDiaristaMapper diaristaMapper,
        IUsuarioRepository usuarioRepository,
        IConsultaEnderecoService consultaEnderecoService)
    {
        _diaristaMapper = diaristaMapper;
        _usuarioRepository = usuarioRepository;
        _consultaEnderecoService = consultaEnderecoService;
    }

    public DiaristaLocalidadePagedResponse FindByCep(string cep)
    {
        var codigoIbge = _consultaEnderecoService.FindEnderecoByCep(cep).Ibge;
        var result = _usuarioRepository.FindByCidadesAtentidasCodigoIbge(codigoIbge, new PagedFilter(1, 6));
        return new DiaristaLocalidadePagedResponse(
            result.Elements.Select(_diaristaMapper.ToLocalidadeResponse).ToList(),
            result.PageSize,
            result.TotalElements
        );
    }
}
