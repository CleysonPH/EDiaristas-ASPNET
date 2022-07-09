namespace EDiaristas.Api.Usuarios.Dtos;

public class UsuarioRequest
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordConfirmation { get; set; } = string.Empty;
    public int TipoUsuario { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public DateTime Nascimento { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string ChavePix { get; set; } = string.Empty;
}