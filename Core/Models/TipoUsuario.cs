namespace EDiaristas.Core.Models;

public enum TipoUsuario
{
    Cliente = 1,
    Diarista = 2
}

public static class TipoUsuarioExtensions
{
    public static int ToInt(this TipoUsuario tipoUsuario)
    {
        return (int)tipoUsuario;
    }

    public static TipoUsuario ToTipoUsuario(this int tipoUsuario)
    {
        return (TipoUsuario)tipoUsuario;
    }

    public static bool IsCliente(this int tipoUsuario)
    {
        return tipoUsuario == (int)TipoUsuario.Cliente;
    }

    public static bool IsDiarista(this int tipoUsuario)
    {
        return tipoUsuario == (int)TipoUsuario.Diarista;
    }
}