namespace EDiaristas.Core.Exceptions;

public class DiariaNotFoundException : ModelNotFoundException
{
    public DiariaNotFoundException(string? message = "Diária não encontrada") : base(message)
    { }
}