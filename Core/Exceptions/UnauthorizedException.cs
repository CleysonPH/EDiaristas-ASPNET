namespace EDiaristas.Core.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException() : base("Usuário não autorizado")
    { }
}