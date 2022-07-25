using EDiaristas.Api.CidadesAtentidas.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.CidadesAtentidas.Mappers;

public interface ICidadeAtendidaMapper
{
    CidadeAtendidaResponse ToResponse(CidadeAtendida model);
}