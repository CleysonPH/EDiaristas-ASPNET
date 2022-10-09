namespace EDiaristas.Core.Services.Email;

public interface IEmailService
{
    Task EnviarAsync(EmailParams emailParams);
}