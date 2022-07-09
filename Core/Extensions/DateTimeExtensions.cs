namespace EDiaristas.Core.Exceptions;

public static class DateTimeExtensions
{
    public static int GetIdade(this DateTime dateTime)
    {
        var idade = DateTime.Now.Year - dateTime.Year;
        if (DateTime.Now.Month < dateTime.Month || (DateTime.Now.Month == dateTime.Month && DateTime.Now.Day < dateTime.Day))
        {
            idade--;
        }
        return idade;
    }
}