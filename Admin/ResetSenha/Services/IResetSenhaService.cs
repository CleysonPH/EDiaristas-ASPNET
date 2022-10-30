using EDiaristas.Admin.ResetSenha.Dtos;

namespace EDiaristas.Admin.ResetSenha.Services;

public interface IResetSenhaService
{
    void SolicitarResetSenha(SolicitarResetSenhaForm solicitarResetSenhaForm);
    void ConfirmarResetSenha(string token, ConfirmarResetSenhaForm confirmarResetSenhaForm);
}