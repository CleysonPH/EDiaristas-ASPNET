namespace EDiaristas.Core.Services.PasswordReset.Adapters;

public interface IPasswordResetService
{
    string CriarPasswordResetToken(string email);
    void ResetarSenha(string token, string senha);
}