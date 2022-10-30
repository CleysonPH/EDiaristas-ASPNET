namespace EDiaristas.Core.Exceptions;

public class PasswordResetTokenNotFoundException : ModelNotFoundException
{
    public PasswordResetTokenNotFoundException(string? message = "Token de reset de senha não encontrado") : base(message)
    { }
}