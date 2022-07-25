using System.Text.Json.Serialization;

namespace EDiaristas.Core.Services.ConsultaCidade.Providers.Ibge;

public partial class IbgeResponse
{
    public string Id { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public Microrregiao Microrregiao { get; set; } = new Microrregiao();
}

public partial class Microrregiao
{
    public Mesorregiao Mesorregiao { get; set; } = new Mesorregiao();
}

public partial class Mesorregiao
{
    [JsonPropertyName("UF")]
    public Uf Uf { get; set; } = new Uf();
}

public partial class Uf
{
    public string Sigla { get; set; } = string.Empty;
}