using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Diarias.Mappers;

public interface IDiariaMapper
{
    DiariaResponse ToResponse(Diaria diaria);
    Diaria ToModel(DiariaRequest request);
}