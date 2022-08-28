using System.Text.Json.Serialization;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Diarias.Dtos;

public class CancelamentoRequest
{
    public string MotivoCancelamento { get; set; } = string.Empty;

    [JsonIgnore]
    public Diaria Diaria { get; set; } = new Diaria();
}