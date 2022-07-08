using EDiaristas.Core.Services.ConsultaEndereco.Dtos;

namespace EDiaristas.Core.Services.ConsultaEndereco.Adapters;

public interface IConsultaEnderecoService
{
    EnderecoResponse FindEnderecoByCep(string cep);
}