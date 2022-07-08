using EDiaristas.Api.Diaristas.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Diaristas.Mappers;

public class DiaristaMapper : IDiaristaMapper
{
    public DiaristaLocalidadeResponse ToLocalidadeResponse(Usuario usuario)
    {
        return new DiaristaLocalidadeResponse
        {
            Id = usuario.Id,
            NomeCompleto = usuario.NomeCompleto,
            Reputacao = usuario.Reputacao ?? 0,
            FotoUsuario = "",
            Cidade = ""
        };
    }
}