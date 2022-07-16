namespace EDiaristas.Core.Services.PasswordEnconder.Adapters;

public interface IPasswordEnconderService
{
    string Enconde(string password);
    bool Verify(string password, string hash);
}