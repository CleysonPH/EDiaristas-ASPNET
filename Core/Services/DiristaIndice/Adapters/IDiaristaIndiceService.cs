using EDiaristas.Core.Models;

namespace EDiaristas.Core.Services.DiaristaIndice.Adapters;

public interface IDiaristaIndiceService
{
    Usuario SelecionarMelhorDiarista(Diaria diaria);
}