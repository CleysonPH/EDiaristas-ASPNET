using EDiaristas.Api.Diaristas.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Diaristas.Mappers;

public interface IDiaristaMapper
{
    DiaristaLocalidadeResponse ToLocalidadeResponse(Usuario usuario);
}