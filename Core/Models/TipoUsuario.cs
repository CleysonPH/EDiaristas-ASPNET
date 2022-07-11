namespace EDiaristas.Core.Models;

public enum TipoUsuario
{
    Cliente = 1,
    Diarista = 2,
    Admin = 3
}

public static class TipoUsuarioExtensions
{
    public static string ToTipoUsuarioName(this TipoUsuario tipoUsuario)
    {
        switch (tipoUsuario)
        {
            case TipoUsuario.Cliente:
                return Roles.Cliente;
            case TipoUsuario.Diarista:
                return Roles.Diarista;
            case TipoUsuario.Admin:
                return Roles.Admin;
            default:
                throw new ArgumentOutOfRangeException(nameof(tipoUsuario), tipoUsuario, null);
        }
    }

    public static TipoUsuario ToTipoUsuario(this string tipoUsuario)
    {
        switch (tipoUsuario)
        {
            case Roles.Cliente:
                return TipoUsuario.Cliente;
            case Roles.Diarista:
                return TipoUsuario.Diarista;
            case Roles.Admin:
                return TipoUsuario.Admin;
            default:
                throw new ArgumentOutOfRangeException(nameof(tipoUsuario), tipoUsuario, null);
        }
    }

    public static TipoUsuario ToTipoUsuario(this int tipoUsuario)
    {
        switch (tipoUsuario)
        {
            case 1:
                return TipoUsuario.Cliente;
            case 2:
                return TipoUsuario.Diarista;
            case 3:
                return TipoUsuario.Admin;
            default:
                throw new ArgumentOutOfRangeException(nameof(tipoUsuario), tipoUsuario, null);
        }
    }

    public static int ToTipoUsuarioInt(this TipoUsuario tipoUsuario)
    {
        switch (tipoUsuario)
        {
            case TipoUsuario.Cliente:
                return 1;
            case TipoUsuario.Diarista:
                return 2;
            case TipoUsuario.Admin:
                return 3;
            default:
                throw new ArgumentOutOfRangeException(nameof(tipoUsuario), tipoUsuario, null);
        }
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