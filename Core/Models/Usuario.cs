using Microsoft.EntityFrameworkCore.Infrastructure;

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
    public int? EnderecoId { get; set; }

    private ICollection<CidadeAtendida>? _cidadesAtendidas;
    private ICollection<Diaria>? _candidaturas;
    private EnderecoDiarista? _endereco;

    private ILazyLoader? LazyLoader { get; set; }

    public ICollection<CidadeAtendida> CidadesAtendidas
    {
        get => LazyLoader.Load(this, ref _cidadesAtendidas) ?? new List<CidadeAtendida>();
        set => _cidadesAtendidas = value;
    }

    public ICollection<Diaria> Candidaturas
    {
        get => LazyLoader.Load(this, ref _candidaturas) ?? new List<Diaria>();
        set => _candidaturas = value;
    }

    public EnderecoDiarista? Endereco
    {
        get => LazyLoader.Load(this, ref _endereco);
        set => _endereco = value;
    }

    public Usuario()
    { }

    public Usuario(ILazyLoader? lazyLoader)
    {
        LazyLoader = lazyLoader;
    }
}