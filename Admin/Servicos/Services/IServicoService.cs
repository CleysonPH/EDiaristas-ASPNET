using EDiaristas.Admin.Servicos.Dtos;

namespace EDiaristas.Admin.Servicos.Services;

public interface IServicoService
{
    ICollection<ServicoSummary> FindAll();
    void Create(ServicoForm form);
    void DeleteById(int id);
    ServicoForm FindById(int id);
    void UpdateById(int id, ServicoForm form);
}