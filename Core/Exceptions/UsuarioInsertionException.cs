namespace EDiaristas.Core.Exceptions;

public class UsuarioInsertionException : Exception
{
    public UsuarioInsertionException(string? message) : base(message)
    { }
}