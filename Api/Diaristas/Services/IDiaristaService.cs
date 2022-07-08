using EDiaristas.Api.Diaristas.Dtos;

namespace EDiaristas.Api.Diaristas.Services;

public interface IDiaristaService
{
    DiaristaLocalidadePagedResponse FindByCep(string cep);
    DisponibilidadeResponse VerificarDisponibilidadePorCep(string cep);
}