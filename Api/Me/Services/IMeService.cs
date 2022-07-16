using EDiaristas.Api.Me.Dtos;

namespace EDiaristas.Api.Me.Services;

public interface IMeService
{
    MeResponse ExibirUsuarioAutenticado();
}