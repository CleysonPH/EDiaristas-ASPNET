using EDiaristas.Api.Servicos.Dtos;

namespace EDiaristas.Api.Servicos.Services;

public interface IServicoService
{
    ICollection<ServicoResponse> FindAll();
}