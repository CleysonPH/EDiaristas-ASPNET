using Microsoft.AspNetCore.Identity;

namespace EDiaristas.Core.Models;

public class Usuario : IdentityUser<int>
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string? Cpf { get; set; }
    public DateTime? Nascimento { get; set; }
    public double? Reputacao { get; set; }
    public string? ChavePix { get; set; }

    public ICollection<CidadeAtendida>? CidadesAtendidas { get; set; }
}