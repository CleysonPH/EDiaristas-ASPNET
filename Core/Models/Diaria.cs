namespace EDiaristas.Core.Models;

public class Diaria
{
    public int Id { get; set; }
    public DateTime DataAtendimento { get; set; }
    public int TempoAtendimento { get; set; }
    public DiariaStatus status { get; set; }
    public decimal Preco { get; set; }
    public decimal ValorComissao { get; set; }
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
    public string? MotivoCancelamento { get; set; }
    public int ClienteId { get; set; }
    public int? DiaristaId { get; set; }

    public Usuario Cliente { get; set; } = new Usuario();
    public Usuario? Diarista { get; set; }
    public ICollection<Usuario> Candidatos { get; set; } = new List<Usuario>();
}