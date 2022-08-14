using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EDiaristas.Core.Models;

public class Diaria : Auditable
{
    public int Id { get; set; }
    public DateTime DataAtendimento { get; set; }
    public int TempoAtendimento { get; set; }
    public DiariaStatus Status { get; set; }
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
    public int ServicoId { get; set; }

    private Servico? _servico;
    private Usuario? _cliente;
    private Usuario? _diarista;
    private ICollection<Usuario>? _candidatos;

    private ILazyLoader? LazyLoader { get; set; }

    public Servico Servico
    {
        get => LazyLoader.Load(this, ref _servico) ?? new Servico();
        set => _servico = value;
    }

    public Usuario Cliente
    {
        get => LazyLoader.Load(this, ref _cliente) ?? new Usuario();
        set => _cliente = value;
    }

    public Usuario? Diarista
    {
        get => LazyLoader.Load(this, ref _diarista);
        set => _diarista = value;
    }

    public ICollection<Usuario> Candidatos
    {
        get => LazyLoader.Load(this, ref _candidatos) ?? new List<Usuario>();
        set => _candidatos = value;
    }

    public Diaria()
    { }

    public Diaria(ILazyLoader? lazyLoader)
    {
        LazyLoader = lazyLoader;
    }
}