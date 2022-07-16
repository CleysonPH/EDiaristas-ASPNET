using EDiaristas.Api.Me.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Me.Mappers;

public interface IMeMapper
{
    MeResponse ToResponse(Usuario usuario);
}