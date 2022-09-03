using EDiaristas.Admin.Diarias.Dtos;
using EDiaristas.Admin.Diarias.Mappers;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
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

    public ICollection<DiariaSummary> Listar(string clienteNome, string status)
    {
        var filtro = new DiariaFiltro
        {
            ClienteNome = clienteNome,
            Statuses = string.IsNullOrWhiteSpace(status) ? new List<DiariaStatus>() : status.Split(',').Select(s => s.ToDiariaStatus()).ToList()
        };
        return _diariaRepository.FindAll(d => d.DataAtendimento, filtro, false)
            .Select(_diariaMapper.ToSummary)
            .ToList();
    }

    public void MarcarComoTransferida(int diariaId)
    {
        var diaria = _diariaRepository.FindById(diariaId);
        if (diaria is null)
        {
            throw new DiariaNotFoundException();
        }
        if (new[] { DiariaStatus.Concluido, DiariaStatus.Avaliado }.Contains(diaria.Status))
        {
            diaria.Status = DiariaStatus.Transferido;
            _diariaRepository.Update(diaria);
        }
    }
}