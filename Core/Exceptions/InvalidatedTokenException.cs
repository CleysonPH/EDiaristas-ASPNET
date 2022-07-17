namespace EDiaristas.Core.Exceptions;

public class InvalidatedTokenException : Exception
{
    public InvalidatedTokenException(string? message = "Token foi invalidado") : base(message)
    { }
}