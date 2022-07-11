using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Usuarios.Dtos;

public class UsuarioRequest
{
    [BindProperty(Name = "nome_completo")]
    public string NomeCompleto { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    [BindProperty(Name = "password_confirmation")]
    public string PasswordConfirmation { get; set; } = string.Empty;

    [BindProperty(Name = "tipo_usuario")]
    public int TipoUsuario { get; set; }

    public string Cpf { get; set; } = string.Empty;

    public DateTime Nascimento { get; set; }

    public string Telefone { get; set; } = string.Empty;

    [BindProperty(Name = "chave_pix")]
    public string ChavePix { get; set; } = string.Empty;
}