namespace EDiaristas.Core.Services.ConsultaDistancia.Adapters;

public interface IConsultaDistanciaService
{
    ConsultaDistanciaResult CalcularDistanciaEntreCeps(string cepOrigem, string cepDestino);
}