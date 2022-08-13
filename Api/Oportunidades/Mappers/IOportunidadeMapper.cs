using EDiaristas.Api.Oportunidades.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Oportunidades.Mappers;

public interface IOportunidadeMapper
{
    OportunidadeResponse ToResponse(Diaria diaria);
}