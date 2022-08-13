using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Repositories.Diarias;
using EDiaristas.Core.Services.Authentication.Adapters;
using FluentValidation;

namespace EDiaristas.Api.Diarias.Services;

public class CandidaturaService : ICandidaturaService
{
    private readonly IDiariaRepository _diariaRepository;
    private readonly IValidator<CandidaturaData> _candidaturaValidator;
    private readonly ICustomAuthenticationService _authenticationService;

    public CandidaturaService(
        IDiariaRepository diariaRepository,
        IValidator<CandidaturaData> candidaturaValidator,
        ICustomAuthenticationService authenticationService)
    {
        _diariaRepository = diariaRepository;
        _candidaturaValidator = candidaturaValidator;
        _authenticationService = authenticationService;
    }

    public MessageResponse Candidatar(int diariaId)
    {
        var diaria = _diariaRepository.FindById(diariaId);
        if (diaria is null)
        {
            throw new DiariaNotFoundException();
        }
        var usuarioAutenticado = _authenticationService.GetUsuarioAutenticado();
        _candidaturaValidator.ValidateAndThrow(new CandidaturaData(diaria, usuarioAutenticado));
        diaria.Candidatos.Add(usuarioAutenticado);
        _diariaRepository.Update(diaria);
        return new MessageResponse
        {
            Message = "Candidatura realizada com sucesso",
        };
    }
}