namespace EDiaristas.Core.Exceptions;

public class ModelNotFoundException : Exception
{
    public ModelNotFoundException(string? message = "Model não encontrado") : base(message)
    { }
}