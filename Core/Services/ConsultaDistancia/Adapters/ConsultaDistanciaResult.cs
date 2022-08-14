namespace EDiaristas.Core.Services.ConsultaDistancia.Adapters;

public class ConsultaDistanciaResult
{
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public double DistanciaEmKm { get; set; }
}