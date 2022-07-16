using EDiaristas.Core.Services.PasswordEnconder.Adapters;

namespace EDiaristas.Core.Services.PasswordEnconder.Providers;

public class BCryptService : IPasswordEnconderService
{
    public string Enconde(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}