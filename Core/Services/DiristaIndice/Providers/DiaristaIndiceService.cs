using EDiaristas.Core.Models;
using EDiaristas.Core.Services.ConsultaDistancia.Adapters;
using EDiaristas.Core.Services.DiaristaIndice.Adapters;

namespace EDiaristas.Core.Services.DiaristaIndice.Providers;

public class DiaristaIndiceService : IDiaristaIndiceService
{
    private readonly IConsultaDistanciaService _consultaDistanciaService;

    public DiaristaIndiceService(IConsultaDistanciaService consultaDistanciaService)
    {
        _consultaDistanciaService = consultaDistanciaService;
    }

    public Usuario SelecionarMelhorDiarista(Diaria diaria)
    {
        validarDiaria(diaria);
        var melhorIndice = 0.0;
        Usuario melhorCandidato = diaria.Candidatos.First();
        foreach (var candidato in diaria.Candidatos)
        {
            if (candidato.Endereco is null)
            {
                throw new ArgumentException("O candidato não possui endereço");
            }
            double distancia = 0.0;
            try
            {
                distancia = _consultaDistanciaService.CalcularDistanciaEntreCeps(candidato.Endereco.Cep, diaria.Cep).DistanciaEmKm;
            }
            catch (ConsultaDistanciaException)
            {
                distancia = Double.MaxValue;
            }
            var indiceCandidatoAtual = ((candidato.Reputacao ?? 0.0) - (distancia / 10.0)) / 2.0;

            if (indiceCandidatoAtual > melhorIndice)
            {
                melhorIndice = indiceCandidatoAtual;
                melhorCandidato = candidato;
            }
        }
        return melhorCandidato;
    }

    private void validarDiaria(Diaria diaria)
    {
        if (diaria.Candidatos.Count == 0)
        {
            throw new ArgumentException("A lista de candidatos não pode ser vazia");
        }
    }
}