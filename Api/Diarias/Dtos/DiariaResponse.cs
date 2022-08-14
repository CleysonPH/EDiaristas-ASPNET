using EDiaristas.Api.Common.Dtos;

namespace EDiaristas.Api.Diarias.Dtos;

public class DiariaResponse : ResourceResponse
{
    public int Id { get; set; }
    public int Status { get; set; }
    public string? MotivoCancelamento { get; set; }
    public string? NomeServico { get; set; } = string.Empty;
    public string? Complemento { get; set; }
    public DateTime DataAtendimento { get; set; }
    public int TempoAtendimento { get; set; }
    public decimal Preco { get; set; }
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string CodigoIbge { get; set; } = string.Empty;
    public int QuantidadeQuartos { get; set; }
    public int QuantidadeSalas { get; set; }
    public int QuantidadeCozinhas { get; set; }
    public int QuantidadeBanheiros { get; set; }
    public int QuantidadeQuintais { get; set; }
    public int QuantidadeOutros { get; set; }
    public string? Observacoes { get; set; }
    public int Servico { get; set; }
    public DateTime? CreatedAt { get; set; }
    public UsuarioDiariaResponse? Cliente { get; set; } = new UsuarioDiariaResponse();
    public UsuarioDiariaResponse? Diarista { get; set; } = new UsuarioDiariaResponse();
}