using EDiaristas.Api.Oportunidades.Dtos;

namespace EDiaristas.Api.Oportunidades.Services;

public interface IOportunidadeService
{
    ICollection<OportunidadeResponse> BuscarOportunidades();
}