using System.Text.Json;
using EDiaristas.Core.Services.ConsultaEndereco.Adapters;
using EDiaristas.Core.Services.ConsultaEndereco.Dtos;
using EDiaristas.Core.Services.ConsultaEndereco.Exceptions;

namespace EDiaristas.Core.Services.ConsultaEndereco.Providers;

public class ViaCepService : IConsultaEnderecoService
{
    private const string Url = "https://viacep.com.br/ws/{0}/json/";
    private readonly HttpClient _httpClient;

    public ViaCepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public EnderecoResponse FindEnderecoByCep(string cep)
    {
        var url = string.Format(Url, cep);
        var response = _httpClient.GetAsync(url).Result;
        if (response.IsSuccessStatusCode)
        {
            var json = response.Content.ReadAsStringAsync().Result;
            var endereco = JsonSerializer.Deserialize<EnderecoResponse>(
                json,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
            ) ?? new EnderecoResponse();
            if (string.IsNullOrWhiteSpace(endereco.Logradouro))
            {
                throw new CepNotFoundException();
            }
            return endereco;
        }
        throw new InvalidCepException();
    }
}
