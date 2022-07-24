using EDiaristas.Api.Diarias.Dtos;

namespace EDiaristas.Api.Diarias.Services;

public interface IDiariaService
{
    DiariaResponse Cadastrar(DiariaRequest request);
}