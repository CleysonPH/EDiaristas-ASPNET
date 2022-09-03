using EDiaristas.Admin.Diarias.Dtos;

namespace EDiaristas.Admin.Diarias.Services;

public interface IDiariaService
{
    ICollection<DiariaSummary> Listar(string clienteNome, string status);
    void MarcarComoTransferida(int diariaId);
}