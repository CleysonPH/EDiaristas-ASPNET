namespace EDiaristas.Admin.Diarias.Dtos;

public class DiariaSummary
{
    public int Id { get; set; }
    public String Status { get; set; } = string.Empty;
    public String NomeCliente { get; set; } = string.Empty;
    public String NomeDiarista { get; set; } = string.Empty;
    public String ChavePix { get; set; } = string.Empty;
    public String DataAtendimento { get; set; } = string.Empty;
    public string Preco { get; set; } = string.Empty;
    public string Comissao { get; set; } = string.Empty;
    public string Transferencia { get; set; } = string.Empty;
}