namespace EDiaristas.Core.Exceptions;

public class ModelNotFoundExceptionException : Exception
{
    public ModelNotFoundExceptionException(string? message = "Model não encontrado") : base(message)
    { }
}