namespace EDiaristas.Core.Exceptions;

public class AuthenticationException : Exception
{
    public AuthenticationException(string? message = "Houve um erro na autenticação") : base(message)
    { }
}