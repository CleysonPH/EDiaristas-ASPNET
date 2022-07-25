using System.Text.Json;
using EDiaristas.Core.Services.ConsultaCidade.Adapters;

namespace EDiaristas.Core.Services.ConsultaCidade.Providers.Ibge;

public class IbgeConsultaCidadeService : IConsultaCidadeService
{
    private const string Url = "https://servicodados.ibge.gov.br/api/v1/localidades/municipios/{0}";
    private readonly HttpClient _httpClient;

    public IbgeConsultaCidadeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public ConsultaCidadeResult BuscarCidadePorCodigoIbge(string codigoIbge)
    {
        var url = string.Format(Url, codigoIbge);
        var response = _httpClient.GetAsync(url).Result;
        try
        {
            return tryBuscarCidadePorCodigoIbge(response);
        }
        catch (JsonException)
        {
            throw new ConsultaCidadeException("Código IBGE não encontrado");
        }
    }

    private ConsultaCidadeResult tryBuscarCidadePorCodigoIbge(HttpResponseMessage response)
    {
        var json = response.Content.ReadAsStringAsync().Result;
        var ibgeResponse = JsonSerializer.Deserialize<IbgeResponse>(
            json,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
        ) ?? new IbgeResponse();

        return new ConsultaCidadeResult
        {
            Ibge = ibgeResponse.Id,
            Cidade = ibgeResponse.Nome,
            Estado = ibgeResponse.Microrregiao.Mesorregiao.Uf.Sigla
        };
    }
}