namespace EDiaristas.Api.Common.Dtos;

public class TokenResponse
{
    public string Access { get; set; } = string.Empty;
    public string Refresh { get; set; } = string.Empty;
}