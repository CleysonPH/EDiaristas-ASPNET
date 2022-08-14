using System.Text.Json;
using System.Text.RegularExpressions;
using EDiaristas.Core.Services.ConsultaDistancia.Adapters;

namespace EDiaristas.Core.Services.ConsultaDistancia.Providers.GoogleMatrix;

public class GoogleMatrixService : IConsultaDistanciaService
{
    private const string Url = "https://maps.googleapis.com/maps/api/distancematrix/json?destinations={0}&origins={1}&key={2}";
    private readonly HttpClient _httpClient;
    private readonly string _googleMatrixApiKey;

    public GoogleMatrixService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _googleMatrixApiKey = configuration.GetValue<string>("ConsultaEndereco:GoogleMatrixApiKey");
    }

    public ConsultaDistanciaResult CalcularDistanciaEntreCeps(string cepOrigem, string cepDestino)
    {
        var cepOrigemFormatado = formataCep(cepOrigem);
        var cepDestinoFormatado = formataCep(cepDestino);
        var url = string.Format(Url, cepDestinoFormatado, cepOrigemFormatado, _googleMatrixApiKey);
        var response = _httpClient.GetAsync(url).Result;
        if (response.IsSuccessStatusCode)
        {
            var json = response.Content.ReadAsStringAsync().Result;
            var consultaDistancia = JsonSerializer.Deserialize<GoogleMatrixResponse>(
                json,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
            ) ?? new GoogleMatrixResponse();
            if (consultaDistancia.Rows.Count > 0 &&
                consultaDistancia.Rows[0].Elements.Count > 0 &&
                consultaDistancia.Rows[0].Elements[0].Status == "NOT_FOUND")
            {
                throw new ConsultaDistanciaException("CEP não encontrado");
            }
            return new ConsultaDistanciaResult
            {
                Origem = cepOrigem,
                Destino = cepDestino,
                DistanciaEmKm = converteDistanciaEmKm(consultaDistancia.Rows[0].Elements[0].Distance.Value)
            };
        }
        throw new ConsultaDistanciaException("Erro ao consultar o serviço");
    }

    private string formataCep(string cep)
    {
        validarCep(cep);
        return cep.Insert(5, "-");
    }

    private void validarCep(string cep)
    {
        if (cep.Length != 8)
        {
            throw new ConsultaDistanciaException("CEP deve ter oito dígitos");
        }
        if (!Regex.IsMatch(cep, @"^\d{8}$"))
        {
            throw new ConsultaDistanciaException("CEP deve conter apenas números");
        }
    }

    private double converteDistanciaEmKm(int distanciaEmMetros)
    {
        return distanciaEmMetros / 1000.0;
    }
}