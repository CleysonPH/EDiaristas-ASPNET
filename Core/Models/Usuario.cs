namespace EDiaristas.Core.Models;

public class Usuario
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public TipoUsuario TipoUsuario { get; set; }
    public string? Cpf { get; set; }
    public DateTime? Nascimento { get; set; }
    public string? Telefone { get; set; } = string.Empty;
    public double? Reputacao { get; set; }
    public string? ChavePix { get; set; }

    public ICollection<CidadeAtendida> CidadesAtendidas { get; set; } = new List<CidadeAtendida>();
    public ICollection<Diaria> Candidaturas { get; set; } = new List<Diaria>();
}