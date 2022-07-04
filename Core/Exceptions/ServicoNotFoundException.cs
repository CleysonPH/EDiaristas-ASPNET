namespace EDiaristas.Core.Exceptions;

public class ServicoNotFoundException : ModelNotFoundExceptionException
{
    public ServicoNotFoundException(string? message = "Serviço não encontrado") : base(message)
    { }
}