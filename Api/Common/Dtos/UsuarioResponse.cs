namespace EDiaristas.Api.Common.Dtos;

public class UsuarioResponse : ResourceResponse
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int TipoUsuario { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public DateTime Nascimento { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string ChavePix { get; set; } = string.Empty;
    public string? FotoUsuario { get; set; } = string.Empty;
}