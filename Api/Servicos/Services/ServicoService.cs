using EDiaristas.Api.Servicos.Dtos;
using EDiaristas.Api.Servicos.Mappers;
using EDiaristas.Core.Repositories.Servicos;

namespace EDiaristas.Api.Servicos.Services;

public class ServicoService : IServicoService
{
    private readonly IServicoMapper _servicoMapper;
    private readonly IServicoRepository _servicoRepository;

    public ServicoService(IServicoMapper servicoMapper, IServicoRepository servicoRepository)
    {
        _servicoMapper = servicoMapper;
        _servicoRepository = servicoRepository;
    }

    public ICollection<ServicoResponse> FindAll()
    {
        return _servicoRepository.FindAll(x => x.Posicao)
            .Select(_servicoMapper.ToResponse)
            .ToList();
    }
}