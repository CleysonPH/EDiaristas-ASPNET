namespace EDiaristas.Core.Exceptions;

public class PasswordResetTokenExpiredException : Exception
{
    public PasswordResetTokenExpiredException(string? message = "Token de reset de senha expirado") : base(message)
    { }
}