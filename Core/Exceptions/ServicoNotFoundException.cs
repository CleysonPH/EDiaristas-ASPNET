namespace EDiaristas.Core.Exceptions;

public class ServicoNotFoundException : ModelNotFoundException
{
    public ServicoNotFoundException(string? message = "Serviço não encontrado") : base(message)
    { }
}