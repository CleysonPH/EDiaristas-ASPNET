using EDiaristas.Admin.Diarias.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Admin.Diarias.Mappers;

public interface IDiariaMapper
{
    DiariaSummary ToSummary(Diaria diaria);
}