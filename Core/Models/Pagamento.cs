using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EDiaristas.Core.Models;

public class Pagamento : BaseModel
{
    public PagamentoStatus Status { get; set; }
    public decimal Valor { get; set; }
    public string TransacaoId { get; set; } = string.Empty;
    public int DiariaId { get; set; }

    private ILazyLoader? LazyLoader { get; set; }

    private Diaria? _diaria;
    public Diaria Diaria
    {
        get => LazyLoader.Load(this, ref _diaria) ?? new Diaria();
        set => _diaria = value;
    }

    public Pagamento()
    { }

    public Pagamento(ILazyLoader? lazyLoader)
    {
        LazyLoader = lazyLoader;
    }
}