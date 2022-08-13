using EDiaristas.Api.Common.Dtos;

namespace EDiaristas.Api.Diarias.Services;

public interface ICandidaturaService
{
    MessageResponse Candidatar(int diariaId);
}