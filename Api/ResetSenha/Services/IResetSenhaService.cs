using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.ResetSenha.Dtos;

namespace EDiaristas.Api.ResetSenha.Services;

public interface IResetSenhaService
{
    MessageResponse SolicitarResetSenha(SolicitarResetSenhaRequest request);
    MessageResponse ConfirmaResetSenha(ConfirmaResetSenhaRequest request);
}