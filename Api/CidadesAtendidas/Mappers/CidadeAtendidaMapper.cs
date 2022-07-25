using EDiaristas.Api.CidadesAtentidas.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.CidadesAtentidas.Mappers;

public class CidadeAtendidaMapper : ICidadeAtendidaMapper
{
    public CidadeAtendidaResponse ToResponse(CidadeAtendida model)
    {
        return new CidadeAtendidaResponse
        {
            Id = model.Id,
            Cidade = model.Cidade,
            Estado = model.Estado,
            CodigoIbge = model.CodigoIbge
        };
    }
}