namespace EDiaristas.Core.Services.ConsultaEndereco.Exceptions;

public class InvalidCepException : ConsultaEnderecoServiceException
{
    public InvalidCepException(string message = "O CEP informado é inválido") : base(message)
    { }
}