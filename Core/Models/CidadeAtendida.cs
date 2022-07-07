namespace EDiaristas.Core.Models;

public class CidadeAtendida
{
    public int Id { get; set; }
    public string CodigoIbge { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;

    public ICollection<Usuario>? Usuarios { get; set; }
}