using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Diarias.Dtos;

namespace EDiaristas.Api.Diarias.Services;

public interface ICancelamentoService
{
    MessageResponse Cancelar(int diariaId, CancelamentoRequest cancelamentoRequest);
}