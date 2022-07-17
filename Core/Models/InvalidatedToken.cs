namespace EDiaristas.Core.Models;

public class InvalidatedToken
{
    public int Id { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
}