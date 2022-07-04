using EDiaristas.Admin.Servicos.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Admin.Servicos.Mappers;

public interface IServicoMapper
{
    ServicoSummary ToSummary(Servico servico);
    Servico ToModel(ServicoForm form);
    ServicoForm ToForm(Servico servico);
}