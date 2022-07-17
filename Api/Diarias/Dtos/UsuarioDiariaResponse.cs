namespace EDiaristas.Api.Diarias.Dtos;

public class UsuarioDiariaResponse
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public DateTime? Nascimento { get; set; }
    public string? FotoUsuario { get; set; }
    public string? Telefone { get; set; }
    public int TipoUsuario { get; set; }
    public double? Reputacao { get; set; }
}