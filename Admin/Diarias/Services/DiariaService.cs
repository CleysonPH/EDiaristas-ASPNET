using EDiaristas.Admin.Diarias.Dtos;
using EDiaristas.Admin.Diarias.Mappers;
using EDiaristas.Core.Repositories.Diarias;

namespace EDiaristas.Admin.Diarias.Services;

public class DiariaService : IDiariaService
{
    private readonly IDiariaMapper _diariaMapper;
    private readonly IDiariaRepository _diariaRepository;

    public DiariaService(IDiariaMapper diariaMapper, IDiariaRepository diariaRepository)
    {
        _diariaMapper = diariaMapper;
        _diariaRepository = diariaRepository;
    }

    public ICollection<DiariaSummary> Listar()
    {
        return _diariaRepository.FindAll(d => d.DataAtendimento, false)
            .Select(_diariaMapper.ToSummary)
            .ToList();
    }
}