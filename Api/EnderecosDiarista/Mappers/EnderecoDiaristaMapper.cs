using EDiaristas.Api.EnderecosDiarista.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.EnderecosDiarista.Mappers;

public class EnderecoDiaristaMapper : IEnderecoDiaristaMapper
{
    public EnderecoDiarista ToModel(EnderecoDiaristaRequest request)
    {
        return new EnderecoDiarista
        {
            Logradouro = request.Logradouro,
            Numero = request.Numero,
            Complemento = request.Complemento,
            Bairro = request.Bairro,
            Cidade = request.Cidade,
            Estado = request.Estado,
            Cep = request.Cep,
        };
    }

    public EnderecoDiaristaResponse ToResponse(EnderecoDiarista model)
    {
        return new EnderecoDiaristaResponse
        {
            Id = model.Id,
            Logradouro = model.Logradouro,
            Numero = model.Numero,
            Complemento = model.Complemento,
            Bairro = model.Bairro,
            Cidade = model.Cidade,
            Estado = model.Estado,
            Cep = model.Cep,
        };
    }
}