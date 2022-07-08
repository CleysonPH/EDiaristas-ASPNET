namespace EDiaristas.Core.Services.ConsultaEndereco.Exceptions;

public class CepNotFoundException : ConsultaEnderecoServiceException
{
    public CepNotFoundException(string message = "O CEP informado não foi encontrado") : base(message)
    { }
}