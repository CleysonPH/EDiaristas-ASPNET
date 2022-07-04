namespace EDiaristas.Admin.Usuarios.Dtos;

public class UpdatePasswordForm
{
    public string SenhaAntiga { get; set; } = string.Empty;
    public string NovaSenha { get; set; } = string.Empty;
    public string ConfirmacaoNovaSenha { get; set; } = string.Empty;
}