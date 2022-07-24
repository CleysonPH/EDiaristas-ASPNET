namespace EDiaristas.Core.Exceptions;

public class UsuarioNotFoundException : ModelNotFoundException
{
    public UsuarioNotFoundException(string? message = "Usuário não encontrado") : base(message)
    { }
}