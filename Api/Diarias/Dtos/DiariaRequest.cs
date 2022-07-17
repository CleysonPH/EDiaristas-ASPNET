namespace EDiaristas.Api.Diarias.Dtos;

public class DiariaRequest
{
    public DateTime DataAtendimento { get; set; }
    public int TempoAtendimento { get; set; }
    public decimal Preco { get; set; }
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string? Complemento { get; set; }
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string CodigoIbge { get; set; } = string.Empty;
    public int QuantidadeQuartos { get; set; }
    public int QuantidadeSalas { get; set; }
    public int QuantidadeCozinhas { get; set; }
    public int QuantidadeBanheiros { get; set; }
    public int QuantidadeQuintais { get; set; }
    public int QuantidadeOutros { get; set; }
    public string? Observacoes { get; set; }
    public int Servico { get; set; }
}