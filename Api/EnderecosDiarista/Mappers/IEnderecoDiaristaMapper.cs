using EDiaristas.Api.EnderecosDiarista.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.EnderecosDiarista.Mappers;

public interface IEnderecoDiaristaMapper
{
    EnderecoDiarista ToModel(EnderecoDiaristaRequest request);
    EnderecoDiaristaResponse ToResponse(EnderecoDiarista model);
}