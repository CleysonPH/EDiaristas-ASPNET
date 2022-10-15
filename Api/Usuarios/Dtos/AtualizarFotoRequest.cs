using Microsoft.AspNetCore.Mvc;

namespace EDiaristas.Api.Usuarios.Dtos;

public class AtualizarFotoRequest
{
    [BindProperty(Name = "foto_usuario")]
    public IFormFile FotoUsuario { get; set; } = null!;
}