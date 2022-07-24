namespace EDiaristas.Core.Exceptions;

public class EnderecoDiaristaNotFoundException : ModelNotFoundException
{
    public EnderecoDiaristaNotFoundException(string? message = "Endereço do Diarista não encontrado") : base(message)
    { }
}