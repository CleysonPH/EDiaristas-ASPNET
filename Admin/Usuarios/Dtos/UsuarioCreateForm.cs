namespace EDiaristas.Admin.Usuarios.Dtos;

public class UsuarioCreateForm
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string ConfirmacaoSenha { get; set; } = string.Empty;
}