namespace EDiaristas.Api.CidadesAtentidas.Dtos;

public class CidadeAtendidaResponse
{
    public int Id { get; set; }
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string CodigoIbge { get; set; } = string.Empty;
}