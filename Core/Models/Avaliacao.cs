using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EDiaristas.Core.Models;

public class Avaliacao : Auditable
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public double Nota { get; set; }
    public bool Visibilidade { get; set; }
    public int DiariaId { get; set; }
    public int? AvaliadorId { get; set; }
    public int AvaliadoId { get; set; }

    private Diaria? _diaria;
    private Usuario? _avaliador;
    private Usuario? _avaliado;

    private ILazyLoader? LazyLoader { get; set; }

    public Diaria Diaria
    {
        get => LazyLoader.Load(this, ref _diaria) ?? new Diaria();
        set => _diaria = value;
    }

    public Usuario Avaliador
    {
        get => LazyLoader.Load(this, ref _avaliador) ?? new Usuario();
        set => _avaliador = value;
    }

    public Usuario Avaliado
    {
        get => LazyLoader.Load(this, ref _avaliado) ?? new Usuario();
        set => _avaliado = value;
    }

    public Avaliacao()
    { }

    public Avaliacao(ILazyLoader? lazyLoader)
    {
        LazyLoader = lazyLoader;
    }
}