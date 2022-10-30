namespace EDiaristas.Core.Models;

public class PasswordResetToken : BaseModel
{
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime IssuedAt { get; set; }
    public DateTime ExpirationDate { get; set; }
}