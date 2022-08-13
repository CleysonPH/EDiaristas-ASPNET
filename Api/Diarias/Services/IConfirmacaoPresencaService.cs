using EDiaristas.Api.Common.Dtos;

namespace EDiaristas.Api.Diarias.Services;

public interface IConfirmacaoPresencaService
{
    MessageResponse ConfirmarPresenca(int diariaId);
}