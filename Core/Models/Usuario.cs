using Microsoft.AspNetCore.Identity;

namespace EDiaristas.Core.Models;

public class Usuario : IdentityUser<int>
{
    public string NomeCompleto { get; set; } = string.Empty;
}