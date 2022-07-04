namespace EDiaristas.Admin.Usuarios.Dtos;

public class UsuarioUpdateForm
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}