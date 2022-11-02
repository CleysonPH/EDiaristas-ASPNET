namespace EDiaristas.Core.Models;

public class InvalidatedToken : BaseModel
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
}