using System.Text.Json.Serialization;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Diarias.Dtos;

public class PagamentoRequest
{
    public string CardHash { get; set; } = string.Empty;

    [JsonIgnore]
    public DiariaStatus DiariaStatus { get; set; }
}