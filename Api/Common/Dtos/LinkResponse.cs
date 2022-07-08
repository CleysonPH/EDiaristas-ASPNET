namespace EDiaristas.Api.Common.Dtos;

public class LinkResponse
{
    public string Type { get; set; } = string.Empty;
    public string Rel { get; set; } = string.Empty;
    public string? Uri { get; set; } = string.Empty;
}