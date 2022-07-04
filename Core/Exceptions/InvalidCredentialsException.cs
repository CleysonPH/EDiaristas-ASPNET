namespace EDiaristas.Core.Exceptions;

public class InvalidCredentialsException : AuthenticationException
{
    public InvalidCredentialsException(string? message = "Credenciais inválidas") : base(message)
    { }
}