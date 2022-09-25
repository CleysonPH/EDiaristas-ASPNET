using System.Text.Json.Serialization;

namespace EDiaristas.Api.Usuarios.Dtos;

public class AtualizarUsuarioRequest
{
    [JsonIgnore]
    public int Id { get; set; }

    public string? NomeCompleto { get; set; }
    public string? Email { get; set; }
    public string? Cpf { get; set; }
    public DateTime? Nascimento { get; set; }
    public string? Telefone { get; set; }
    public string? ChavePix { get; set; }
    public string? Password { get; set; }
    public string? NewPassword { get; set; }
    public string? PasswordConfirmation { get; set; }
}