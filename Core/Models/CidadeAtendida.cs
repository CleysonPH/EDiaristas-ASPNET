using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EDiaristas.Core.Models;

public class CidadeAtendida : BaseModel
{
    public string CodigoIbge { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;

    public ICollection<Usuario>? _usuarios;

    private ILazyLoader? LazyLoader { get; set; }

    public ICollection<Usuario> Usuarios
    {
        get => LazyLoader.Load(this, ref _usuarios) ?? new List<Usuario>();
        set => _usuarios = value;
    }

    public CidadeAtendida()
    { }

    public CidadeAtendida(ILazyLoader? lazyLoader)
    {
        LazyLoader = lazyLoader;
    }
}