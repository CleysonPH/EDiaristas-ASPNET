using EDiaristas.Api.Servicos.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Servicos.Mappers;

public interface IServicoMapper
{
    ServicoResponse ToResponse(Servico servico);
}