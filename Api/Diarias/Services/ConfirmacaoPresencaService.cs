using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Diarias;
using FluentValidation;

namespace EDiaristas.Api.Diarias.Services;

public class ConfirmacaoPresencaService : IConfirmacaoPresencaService
{
    private readonly IDiariaRepository _diariaRepository;
    private readonly IValidator<ConfirmacaoPresencaData> _confirmacaoPresencaValidator;

    public ConfirmacaoPresencaService(
        IDiariaRepository diariaRepository,
        IValidator<ConfirmacaoPresencaData> confirmacaoPresencaValidator)
    {
        _diariaRepository = diariaRepository;
        _confirmacaoPresencaValidator = confirmacaoPresencaValidator;
    }

    public MessageResponse ConfirmarPresenca(int diariaId)
    {
        var diaria = _diariaRepository.FindById(diariaId);
        if (diaria is null)
        {
            throw new DiariaNotFoundException();
        }
        _confirmacaoPresencaValidator.ValidateAndThrow(new ConfirmacaoPresencaData(diaria));
        diaria.Status = DiariaStatus.Concluido;
        _diariaRepository.Update(diaria);
        return new MessageResponse
        {
            Message = "Diária confirmada com sucesso!"
        };
    }
}