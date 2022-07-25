namespace EDiaristas.Api.CidadesAtentidas.Dtos;

public partial class CidadesAtendidasRequest
{
    public ICollection<CidadeAtendidaRequest> Cidades { get; set; } = new List<CidadeAtendidaRequest>();
}

public partial class CidadeAtendidaRequest
{
    public string Cidade { get; set; } = string.Empty;
    public string CodigoIbge { get; set; } = string.Empty;
}