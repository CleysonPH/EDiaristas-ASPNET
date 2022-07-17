namespace EDiaristas.Core.Exceptions;

public class UnauthenticatedException : Exception
{
    public UnauthenticatedException() : base("Usuário não autenticado")
    { }
}