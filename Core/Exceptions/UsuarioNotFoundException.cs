namespace EDiaristas.Core.Exceptions;

public class UsuarioNotFoundException : ModelNotFoundExceptionException
{
    public UsuarioNotFoundException(string? message = "Usuário não encontrado") : base(message)
    { }
}