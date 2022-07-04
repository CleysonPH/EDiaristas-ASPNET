namespace EDiaristas.Admin.Auth.Dtos;

public class LoginForm
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public bool LembrarMe { get; set; } = false;
}