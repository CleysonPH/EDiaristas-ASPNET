using EDiaristas.Admin.Servicos.Dtos;
using EDiaristas.Admin.Servicos.Mappers;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Repositories.Servicos;
using FluentValidation;

namespace EDiaristas.Admin.Servicos.Services;

public class ServicoService : IServicoService
{
    private readonly IServicoMapper _servicoMapper;
    private readonly IServicoRepository _servicoRepository;
    private readonly IValidator<ServicoForm> _servicoFormValidator;

    public ServicoService(
        IServicoMapper servicoMapper,
        IServicoRepository servicoRepository,
        IValidator<ServicoForm> servicoFormValidator)
    {
        _servicoMapper = servicoMapper;
        _servicoRepository = servicoRepository;
        _servicoFormValidator = servicoFormValidator;
    }

    public void Create(ServicoForm form)
    {
        _servicoFormValidator.ValidateAndThrow(form);
        var servicoToCreate = _servicoMapper.ToModel(form);
        _servicoRepository.Create(servicoToCreate);
    }

    public void DeleteById(int id)
    {
        if (!_servicoRepository.ExistsById(id))
        {
            throw new ServicoNotFoundException();
        }
        _servicoRepository.DeleteById(id);
    }

    public ICollection<ServicoSummary> FindAll()
    {
        return _servicoRepository.FindAll()
            .Select(s => _servicoMapper.ToSummary(s))
            .ToList();
    }

    public ServicoForm FindById(int id)
    {
        var foundServico = _servicoRepository.FindById(id);
        if (foundServico is null)
        {
            throw new ServicoNotFoundException();
        }
        return _servicoMapper.ToForm(foundServico);
    }

    public void UpdateById(int id, ServicoForm form)
    {
        _servicoFormValidator.ValidateAndThrow(form);
        if (!_servicoRepository.ExistsById(id))
        {
            throw new ServicoNotFoundException();
        }
        var servicoToUpdate = _servicoMapper.ToModel(form);
        servicoToUpdate.Id = id;
        _servicoRepository.Update(servicoToUpdate);
    }
}