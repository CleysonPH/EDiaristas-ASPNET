namespace EDiaristas.Api.ResetSenha.Dtos;

public class ConfirmaResetSenhaRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordConfirmation { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}